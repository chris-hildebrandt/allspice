namespace allspice.Models
{
  public class Step
    {
        public int StepId { get; set; }
        public int? Position { get; set; }
        public string Body { get; set; }
        public int RecipeId { get; set; }
        public string CreatorId { get; set; }

    }
}