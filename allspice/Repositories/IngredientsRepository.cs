using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using allspice.Models;
using Dapper;

namespace allspice.Repositories
{
  public class IngredientsRepository
  {

    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Ingredient> GetRecipeIngredients(int recipeId)
    {
      string sql = @"SELECT * FROM ingredients i WHERE i.recipeId = @recipeId;";
      List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new {recipeId}).ToList();
      return ingredients;
    }

    internal Ingredient GetIngredientById(int id)
    {
      // TODO does this select need to include a filter for the recipeId as well? will there be duplicate i.id's?
      string sql = @"SELECT * FROM ingredients i WHERE i.id = @id";
      Ingredient ingredient = _db.Query<Ingredient>(sql, new {id}).FirstOrDefault();
      return ingredient;
    }
// TODO where are the recipeId and the creatorId coming from? are they on the newIngredient yet?
    internal Ingredient CreateIngredient(Ingredient newIngredient)
    {
      string sql = @"
      INSERT INTO ingredients
      (name, quantity, recipeId, creatorId)
      VALUES
      (@name, @quantity, @recipeId, @creatorId);
      SELECT LAST_INSERT_ID();
      ";
      int id = _db.ExecuteScalar<int>(sql, newIngredient);
      newIngredient.Id = id;
      return newIngredient;
    }

    internal Ingredient EditIngredient(Ingredient ingredientData)
    {
      string sql = @"UPDATE ingredients SET
      name = @name
      quantity = @quantity;";
      int rowsAffected = _db.Execute(sql, ingredientData);
      if(rowsAffected == 0){
        throw new Exception("Unable to edit ingredient");
      }
      return ingredientData;
    }

    internal void DeleteIngredient(int id)
    {
      string sql = @"DELETE FROM ingredients WHERE id = @id";
      _db.Execute(sql, new {id});
    }

  }
}