namespace allspice.Models
{
  public class Favorite
    {
        public int FavoriteId {get; set;}
        public int RecipeId {get; set;}
        public string AccountId {get;set;}
        public Profile Creator {get; set;}

    }
}