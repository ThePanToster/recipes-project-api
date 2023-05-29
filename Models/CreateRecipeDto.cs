namespace recipes_project_api.Models
{
    public class CreateRecipeDto
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public List<Guid> IngredientAmount { get; set; } = new List<Guid>();
    }
}
