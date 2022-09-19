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
  public class FavoritesController : ControllerBase
  {
    private readonly FavoritesService _favoritesService;

    public FavoritesController(FavoritesService favoritesService)
    {
      _favoritesService = favoritesService;
    }

    // TODO get all favorites info somehow to list recipes by popularity

    [HttpGet("{id}")]
    public ActionResult<Favorite> GetFavoriteById(int id)
    {
      try
      {
        Favorite favorite = _favoritesService.GetFavoriteById(id);
        return Ok(favorite);
      }
      catch (System.Exception e)
      {

        return BadRequest(e);
      }
    }

    [HttpPost]
    [Authorize]
    // the body should send a recipe id
    public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite newFav)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newFav.AccountId = userInfo.Id;
        Favorite favorite = _favoritesService.CreateFavorite(newFav);
        return Ok(favorite);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Favorite>> DeleteFavorite(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_favoritesService.DeleteFavorite(userInfo, id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}