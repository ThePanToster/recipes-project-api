using System.ComponentModel.DataAnnotations;

namespace recipes_project_api.Models
{
    public class Recipe
    {
        [Required]
        public Guid Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public List<IngredientAmount> IngredientList { get; set; } = new List<IngredientAmount>();
    }
}
