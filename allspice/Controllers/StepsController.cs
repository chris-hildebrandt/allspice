using System;
using System.Threading.Tasks;
using allspice.Models;
using allspice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// get by stepId, create, edit, delete,
namespace allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StepsController : ControllerBase
  {
    private readonly StepsService _stepsService;
    private readonly RecipesService _recipeService;

  public StepsController(StepsService stepsService, RecipesService recipeService)
  {
   _stepsService = stepsService;
   _recipeService = recipeService;
  }

  [HttpGet("{id}")]
    public ActionResult<Step> GetStepById(int id)
    {
      try
      {
        Step step = _stepsService.GetStepById(id);
        return Ok(step);
      }
      catch (System.Exception e)
      {

        return BadRequest(e);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Step>> CreateStep([FromBody] Step newStep)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Recipe recipe = _recipeService.GetRecipeById(newStep.RecipeId);
        if (recipe.CreatorId != userInfo.Id){
          throw new Exception("You are not authorized to add steps to recipes you did not create.");
        }
        newStep.CreatorId = userInfo.Id;
        Step step = _stepsService.CreateStep(newStep);
        return Ok(step);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Step>> EditStep(int id, [FromBody] Step updatedStep)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        updatedStep.StepId = id;
        if (updatedStep.CreatorId != userInfo.Id)
        {
          throw new Exception("You are not authorized to edit this step");
        }
        return Ok(_stepsService.EditStep(updatedStep));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Step>> DeleteStep(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_stepsService.DeleteStep(userInfo, id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}