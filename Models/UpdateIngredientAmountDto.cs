namespace recipes_project_api.Models
{
    public class UpdateIngredientAmountDto
    {
        public Ingredient? Ingredient { get; set; }
        public int? Amount { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
