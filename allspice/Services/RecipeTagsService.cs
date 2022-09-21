using System;
using System.Collections.Generic;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class RecipeTagsService
    {
        private readonly RecipeTagsRepository _recipeTagsRepo;

        public RecipeTagsService(RecipeTagsRepository recipeTagsRepo) {
          _recipeTagsRepo = recipeTagsRepo;
        }
        
    internal List<RecipeTag> GetRecipeTags(int recipeId)
    {
      List<RecipeTag> recipeTags = _recipeTagsRepo.GetRecipeTags(recipeId);
      return recipeTags;
    }

    internal RecipeTag GetRecipeTagById(int id)
    {
      RecipeTag recipeTag = _recipeTagsRepo.GetRecipeTagById(id);
      if(recipeTag == null){
        throw new Exception("no recipeTag with that Id");
      }
      return recipeTag;
    }

    internal RecipeTag CreateRecipeTag(RecipeTag newRecipeTag)
    {
      return _recipeTagsRepo.CreateRecipeTag(newRecipeTag);
    }

    internal object DeleteRecipeTag(Account userInfo, int id)
    {
      RecipeTag recipeTag = GetRecipeTagById(id);
      if (recipeTag.CreatorId != userInfo.Id){
        throw new Exception("You are not authorized to delete this recipeTag");
      }
      _recipeTagsRepo.DeleteRecipeTag(recipeTag.RecipeTagId);
      return "Tag removed from recipe";
    }
  }
}