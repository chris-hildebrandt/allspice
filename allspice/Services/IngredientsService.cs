using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class IngredientsService
    {
        private readonly IngredientsRepository _ingredientsRepo;

    public IngredientsService(IngredientsRepository ingredientsRepo)
    {
      _ingredientsRepo = ingredientsRepo;
    }

    internal List<Ingredient> GetRecipeIngredients(int recipeId)
    {
      List<Ingredient> ingredients = _ingredientsRepo.GetRecipeIngredients(recipeId);
      return ingredients;
    }

    internal Ingredient GetIngredientById(int id)
    {
      Ingredient ingredient = _ingredientsRepo.GetIngredientById(id);
        if(ingredient == null){
            throw new Exception("That ingredient id does not exist");
        }
      return ingredient;
    }

    internal Ingredient CreateIngredient(Ingredient newIngredient)
    {
      return _ingredientsRepo.CreateIngredient(newIngredient);
    }

    internal object EditIngredient(Ingredient updatedIngredient)
    {
      Ingredient original = GetIngredientById(updatedIngredient.Id);
      original.Name = updatedIngredient.Name ?? original.Name;
      original.Quantity = updatedIngredient.Quantity ?? original.Quantity;
      return _ingredientsRepo.EditIngredient(original);
    }

    internal string DeleteIngredient(Account userInfo, int id)
    {
      Ingredient ingredient = GetIngredientById(id);
      if (ingredient.CreatorId != userInfo.Id) {
        throw new Exception("You are not authorized to delete this ingredient");
      }
      _ingredientsRepo.DeleteIngredient(ingredient.Id);
      return $"{ingredient.Name} has been deleted";
    }
  }
}