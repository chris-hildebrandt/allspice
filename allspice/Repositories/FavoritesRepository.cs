using System.Data;
using System.Linq;
using allspice.Models;
using Dapper;

namespace allspice.Repositories
{
  public class FavoritesRepository
  {
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal void DeleteFavorite(int id)
    {
      string sql = @"DELETE FROM favorites WHERE favoriteId = @id;";
      _db.Execute(sql, new{id});
    }

    internal Favorite CreateFavorite(Favorite newFav)
    {
      string sql = @"INSERT INTO favorites
      (recipeId, accountId)
      VALUES
      (@recipeId, @accountId);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newFav);
      newFav.FavoriteId = id;
      return newFav;
    }

    internal Favorite GetFavoriteById(int id)
    {
      string sql = @"SELECT FROM favorites WHERE favoriteId = @id";
      Favorite favorite = _db.Query<Favorite>(sql, new{id}).FirstOrDefault();
      return favorite;
    }

internal int GetFavoriteCount(int id){
    string sql = @"SELECT 
     COUNT(accountId)
     FROM recipes r
     JOIN favorites f ON f.recipeId
     WHERE f.recipeId = r.id AND r.id = @id;
     ";
     int favCount = _db.ExecuteScalar<int>(sql, new{id});
     return favCount;
    }
  }
}