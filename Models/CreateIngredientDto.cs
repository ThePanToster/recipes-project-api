namespace recipes_project_api.Models
{
    public class CreateIngredientDto
    {
        public string Name { get; set; } = String.Empty;
        public bool IsUncountable { get; set; } = true;
        public double Price { get; set; } = 0.00;
    }
}
