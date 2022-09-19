namespace allspice.Models
{
  public class RecipeTag
  {
    public int Id { get; set; }
    public int TagId { get; set; }
    public int RecipeId { get; set; }
    // in the future use recipe creatorId instead i.e. one source of truth
    public string CreatorId { get; set; }

  }
}