using System;
using System.Threading.Tasks;
using allspice.Models;
using allspice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// get by i.id, create, edit, delete,
namespace allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _ingredientsService;

    public IngredientsController(IngredientsService ingredientsService)
    {
      _ingredientsService = ingredientsService;
    }

    [HttpGet("{id}")]
    public ActionResult<Ingredient> GetIngredientById(int id) {
      try
      {
        Ingredient ingredient = _ingredientsService.GetIngredientById(id);
        return Ok(ingredient);
      }
      catch (System.Exception e)
      {

        return BadRequest(e);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient newIngredient)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newIngredient.CreatorId = userInfo.Id;
        Ingredient ingredient = _ingredientsService.CreateIngredient(newIngredient);
        return Ok(ingredient);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Ingredient>> EditIngredient(int id, [FromBody] Ingredient updatedIngredient)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        updatedIngredient.Id = id;
        if (updatedIngredient.CreatorId != userInfo.Id)
        {
          throw new Exception("You are not authorized to edit this ingredient");
        }
        return Ok(_ingredientsService.EditIngredient(updatedIngredient));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Ingredient>> DeleteIngredient(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_ingredientsService.DeleteIngredient(userInfo, id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}