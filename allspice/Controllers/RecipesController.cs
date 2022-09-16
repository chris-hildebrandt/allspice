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
    public RecipesController(RecipesService recipesService)
    {
      _recipesService = recipesService;
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

        return BadRequest(e);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Recipe> GetRecipeById(int id)
    {
      try
      {
        return Ok(_recipesService.GetRecipeById(id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e);
      }
    }

    [HttpGet("/profile/{id}")]
    public ActionResult<Recipe> GetRecipeByProfileId(int id)
    {
      try
      {
        return Ok(_recipesService.GetRecipeByProfileId(id));
      }
      catch (System.Exception e)
      {

        return BadRequest(e);
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
        return BadRequest(e);
      }
    }

    // TODO double-check this function and the error message

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> EditRecipe(int id, [FromBody] Recipe updatedRecipe)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        updatedRecipe.Id = id;
        if (updatedRecipe.CreatorId != userInfo.Id)
        {
          throw new Exception("You are not authorized to edit this recipe");
        }
        return Ok(_recipesService.EditRecipe(updatedRecipe));
      }
      catch (System.Exception e)
      {
        return BadRequest(e);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        // if ( id != userInfo.Id)
        // {
        //   throw new Exception("You are not authorized to edit this recipe");
        // }
        return Ok(_recipesService.DeleteRecipe(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}