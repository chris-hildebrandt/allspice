using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using allspice.Models;
using Dapper;

namespace allspice.Repositories
{
  public class RecipesRepository
    {
        private readonly IDbConnection _db;
        public RecipesRepository(IDbConnection db){
            _db = db;
        }

    internal List<Recipe> GetAllRecipes()
    {
      string sql = @"
      SELECT r.*, a.* FROM recipes r JOIN accounts a ON a.id = r.creatorId;";
      List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) => {
        recipe.Creator = account;
        return recipe;
      }).ToList();
      // /\ this formats the recipes into a list
      return recipes;
    }

    internal Recipe GetRecipeById(int id)
    {
      string sql = @"SELECT * FROM recipes r WHERE r.id = @recipeId;";
      Recipe recipe = _db.Query<Recipe>(sql, new {id}).FirstOrDefault();
      return recipe;
    }

    internal List<Recipe> GetRecipesByProfileId(string creatorId)
    {
      string sql = @"SELECT * FROM recipes r JOIN accounts a ON a.id = r.creatorId WHERE r.creatorId = @creatorId;";
      List<Recipe> recipes = _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) => {
        recipe.Creator = account;
        return recipe;
      }).ToList();
      return recipes;
    }

    internal Recipe CreateRecipe(Recipe newRecipe)
    {
      string sql = @"
        INSERT INTO recipes (picture, title, subtitle, description, creatorId)
        VALUES (@picture, @title, @subtitle, @description, @creatorId);
        SELECT LAST_INSERT_ID();
      ";
      // the newRecipe does not have an id yet
      int id = _db.ExecuteScalar<int>(sql, newRecipe);
      // get the new generated id and set the newRecipe prop equal to it
      newRecipe.Id = id;
      return newRecipe;
    }

    internal Recipe EditRecipe(Recipe recipeData)
    {
      string sql = @"UPDATE recipes SET 
      picture = @picture, 
      title = @title,
      subtitle = @subtitle,
      description = @description
      WHERE id = @id;";
      int rowsAffected = _db.Execute(sql, recipeData);
      if (rowsAffected == 0) {
        throw new Exception("Unable to edit recipe");
      }
      return recipeData;
    }

    internal void DeleteRecipe(int id)
    {
      string sql = @"DELETE FROM recipes WHERE id = @id;";
      _db.Execute(sql, new {id});
    }
  }
}