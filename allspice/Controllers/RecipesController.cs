using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using allspice.Models;
using allspice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _recipesService;
    private readonly IngredientsService _ingredientsService;
    private readonly StepsService _stepsService;
    private readonly RecipeTagsService _recipeTagsService;

    public RecipesController(RecipesService recipesService, IngredientsService ingredientsService, StepsService stepsService, RecipeTagsService recipeTagsService)
    {
      _recipesService = recipesService;
      _ingredientsService = ingredientsService;
      _stepsService = stepsService;
      _recipeTagsService = recipeTagsService;
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetAllRecipes()
    {
      try
      {
        List<Recipe> recipes = _recipesService.GetAllRecipes();
        return Ok(recipes);
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // get the recipeTags associated with a recipe
    [HttpGet("{recipeId}/recipe-tags")]
    public ActionResult<List<RecipeTag>> GetRecipeTags(int recipeId)
    {
      try
      {
        List<RecipeTag> recipeTags = _recipeTagsService.GetRecipeTags(recipeId);
        return Ok(recipeTags);
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Recipe> GetRecipeById(int id)
    {
      try
      {
        Recipe recipe = _recipesService.GetRecipeById(id);
        return Ok(recipe);
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // get the ingredients inside of a recipe
    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Ingredient>> GetRecipeIngredients(int recipeId)
    {
      try
      {
        List<Ingredient> ingredients = _ingredientsService.GetRecipeIngredients(recipeId);
        return Ok(ingredients);
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // get the steps inside of a recipe
    [HttpGet("{recipeId}/steps")]
    public ActionResult<List<Step>> GetRecipeSteps(int recipeId)
    {
      try
      {
        List<Step> steps = _stepsService.GetRecipeSteps(recipeId);
        return Ok(steps);
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }
// get list of recipes posted by one specific profile
    [HttpGet("/profiles/{profileId}")]
    public ActionResult<List<Recipe>> GetRecipesByProfileId(string profileId)
    {
      try
      {
        List<Recipe> recipes = _recipesService.GetRecipesByProfileId(profileId);
        return Ok(recipes);
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }
// get a list of all favorited recipes by profileId
      [HttpGet("/favorites/{profileId}")]
    public ActionResult<List<Recipe>> GetFavoriteRecipesByProfileId(string profileId)
    {
      try
      {
        List<Recipe> recipes = _recipesService.GetFavoriteRecipesByProfileId(profileId);
        return Ok(recipes);
      }
      catch (System.Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe newRecipe)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newRecipe.CreatorId = userInfo.Id;
        Recipe recipe = _recipesService.CreateRecipe(newRecipe);
        recipe.Creator = userInfo;
        return Ok(recipe);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> EditRecipe(int id, [FromBody] Recipe updatedRecipe)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        // this id is in the request so we can attach it now instead of doing it in the repo
        updatedRecipe.Id = id;
        if (updatedRecipe.CreatorId != userInfo.Id)
        {
          throw new Exception("You are not authorized to edit this recipe");
        }
        return Ok(_recipesService.EditRecipe(updatedRecipe));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_recipesService.DeleteRecipe(userInfo, id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}