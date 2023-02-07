namespace recipes_project_api.Models
{
    public class UpdateRecipeDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<IngredientAmount>? IngredientAmount { get; set; }
    }
}
