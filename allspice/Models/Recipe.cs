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
        public Account Creator { get; set; }
        public int FavoriteId { get; set; }
    }
}