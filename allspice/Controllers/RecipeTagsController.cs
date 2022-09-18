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
    public class RecipeTagsController : ControllerBase
    {
        private readonly RecipeTagsService _recipeTagsService;

    public RecipeTagsController(RecipeTagsService recipeTagsService)
    {
      _recipeTagsService = recipeTagsService;
    }

    [HttpGet("{id}")]
    public ActionResult<RecipeTag> GetRecipeTagById(int id)
    {
      try
      {
        RecipeTag recipeTag = _recipeTagsService.GetRecipeTagById(id);
        return Ok(recipeTag);
      }
      catch (System.Exception e)
      {

        return BadRequest(e);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<RecipeTag>> CreateRecipeTag([FromBody] RecipeTag newRecipeTag)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        // where do the ids come from? are they in the body already?
        RecipeTag recipeTag = _recipeTagsService.CreateRecipeTag(newRecipeTag);
        return Ok(recipeTag);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<RecipeTag>> DeleteRecipeTag(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_recipeTagsService.DeleteRecipeTag(userInfo, id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}