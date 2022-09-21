using System;
using allspice.Models;
using allspice.Repositories;

namespace allspice.Services
{
  public class FavoritesService
  {
    private readonly FavoritesRepository _favoritesRepository;

    public FavoritesService(FavoritesRepository favoritesRepository)
    {
      _favoritesRepository = favoritesRepository;
    }

    internal int GetFavoriteCount(int id){
      return _favoritesRepository.GetFavoriteCount(id);
    }

    internal Favorite CreateFavorite(Favorite newFav)
    {
      return _favoritesRepository.CreateFavorite(newFav);
    }

    internal object DeleteFavorite(Account userInfo, int id)
    {
      Favorite favorite = GetFavoriteById(id);
      if(favorite.AccountId != userInfo.Id){
        throw new Exception("Unauthorized");
      }
      _favoritesRepository.DeleteFavorite(favorite.FavoriteId);
      return "Removed from favorites";
    }

    internal Favorite GetFavoriteById(int id)
    {
      Favorite favorite = _favoritesRepository.GetFavoriteById(id);
      if(favorite == null){
        throw new Exception("unable to find favorite info");
      }
      return favorite;
    }
  }
}