using System.Collections.Generic;
using System.Data;
using System.Linq;
using allspice.Models;
using Dapper;

namespace allspice.Repositories
{
  public class RecipeTagsRepository
  {
    private readonly IDbConnection _db;

    public RecipeTagsRepository(IDbConnection db)
    {
      _db = db;
    }

// TODO check if the Query needs to know about tags in the <>'s
    internal List<RecipeTag> GetRecipeTags(int recipeId)
    {
      string sql = @"SELECT 
rt.*,
t.*
FROM recipeTags rt
JOIN tags t ON rt.tagId
JOIN recipes r ON rt.recipeId
WHERE rt.tagId = t.id AND rt.recipeId = @recipeId;";
List<RecipeTag> recipeTags = _db.Query<RecipeTag>(sql, new{recipeId}).ToList();
return recipeTags;
    }

    internal RecipeTag GetRecipeTagById(int id)
    {
      string sql = @"SELECT * FROM recipeTags rt WHERE rt.id = @id";
      RecipeTag recipeTag = _db.Query<RecipeTag>(sql, new {id}).FirstOrDefault();
      return recipeTag;
    }

    internal RecipeTag CreateRecipeTag(RecipeTag newRecipeTag)
    {
      string sql = @"INSERT INTO recipeTags
      (tagId, recipeId, creatorId) VALUES (@tagId, @recipeId, @creatorId); SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newRecipeTag);
      newRecipeTag.Id = id;
      return newRecipeTag;
    }

    internal void DeleteRecipeTag(int id)
    {
      string sql = @"DELETE FROM recipeTags WHERE id = @id;";
      _db.Execute(sql, new{id});
    }
  }
}