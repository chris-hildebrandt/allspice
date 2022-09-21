namespace allspice.Models
{
  public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public int RecipeId { get; set; }
        public string CreatorId { get; set; }

    }
}