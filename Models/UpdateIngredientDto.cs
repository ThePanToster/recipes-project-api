namespace recipes_project_api.Models
{
    public class UpdateIngredientDto
    {
        public string? Name { get; set; }
        public bool? IsUncountable { get; set; }
        public double? Price { get; set; }
    }
}
