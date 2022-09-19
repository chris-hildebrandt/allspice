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
      string sql = @"DELETE FROM favorites WHERE id = @id;";
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
      newFav.Id = id;
      return newFav;
    }

    internal Favorite GetFavoriteById(int id)
    {
      string sql = @"SELECT FROM favorites WHERE id = @id";
      Favorite favorite = _db.Query<Favorite>(sql, new{id}).FirstOrDefault();
      return favorite;
    }
  }
}