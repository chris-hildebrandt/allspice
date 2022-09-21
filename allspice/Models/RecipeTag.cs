namespace allspice.Models
{
  public class RecipeTag
  {
    public int RecipeTagId { get; set; }
    public int TagId { get; set; }
    public int RecipeId { get; set; }
    // in the future use recipe creatorId instead i.e. one source of truth
    public string CreatorId { get; set; }
    // FOREIGN KEY?
    public string TagName { get; set; }

  }
}