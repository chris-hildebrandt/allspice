using System.Collections.Generic;

namespace allspice.Models
{
  public class Recipe
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string CreatorId { get; set; }
        public Profile Creator { get; set; }
        public int FavoriteId { get; set; }
        public int Likes {get; set;}
        public List<Ingredient> Ingredients { get; set; }
        public List<Step> Steps { get; set; }
        public List<RecipeTag> Tags { get; set; }
    }
}