using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _recipesRepo;
    private readonly IngredientsService _ingredientsService;
    private readonly StepsService _stepsService;
    private readonly RecipeTagsService _recipeTagsService;
    private readonly FavoritesService _favoritesService;

  public RecipesService(FavoritesService favoritesService, RecipeTagsService recipeTagsService, StepsService stepsService, IngredientsService ingredientsService, RecipesRepository recipesRepo)
  {
   _recipesRepo = recipesRepo;
   _favoritesService = favoritesService;
   _recipeTagsService = recipeTagsService;
   _stepsService = stepsService;
   _ingredientsService = ingredientsService;
  }

  internal List<Recipe> GetAllRecipes()
    {
      List<Recipe> recipes = _recipesRepo.GetAllRecipes();
      recipes.ForEach(r =>{
        r.Ingredients = _ingredientsService.GetRecipeIngredients(r.Id);
        r.Steps = _stepsService.GetRecipeSteps(r.Id);
        r.Tags = _recipeTagsService.GetRecipeTags(r.Id);
        r.Likes = _favoritesService.GetFavoriteCount(r.Id);
      });
      return recipes;
    }
    internal Recipe GetRecipeById(int id)
    {
      Recipe recipe = _recipesRepo.GetRecipeById(id);
      if (recipe == null)
      {
        throw new Exception("That recipe id does not exist");
      }
      return recipe;
    }
    internal List<Recipe> GetRecipesByProfileId(string profileId)
    {
      List<Recipe> recipes = _recipesRepo.GetRecipesByProfileId(profileId);
      return recipes;
    }
    internal List<Recipe> GetFavoriteRecipesByProfileId(string profileId)
    {
      List<Recipe> recipes = _recipesRepo.GetFavoriteRecipesByProfileId(profileId);
      return recipes;
    }

    internal Recipe CreateRecipe(Recipe newRecipe)
    {
      return _recipesRepo.CreateRecipe(newRecipe);
    }

    internal Recipe EditRecipe(Recipe updatedRecipe)
    {
      Recipe original = GetRecipeById(updatedRecipe.Id);
      original.Picture = updatedRecipe.Picture ?? original.Picture;
      original.Title = updatedRecipe.Title ?? original.Title;
      original.Subtitle = updatedRecipe.Subtitle ?? original.Subtitle;
      original.Description = updatedRecipe.Description ?? original.Description;

      return _recipesRepo.EditRecipe(original);
    }

    internal string DeleteRecipe(Account userInfo, int recipeId)
    {
      Recipe recipe = GetRecipeById(recipeId);
      if (recipe.CreatorId != userInfo.Id)
      {
        throw new Exception("You are not authorized to delete this recipe");
      }
      _recipesRepo.DeleteRecipe(recipe.Id);
      return $"{recipe.Title} has been deleted";
    }
  }
}