using System.ComponentModel.DataAnnotations;

namespace recipes_project_api.Models
{
    public class IngredientAmount
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Ingredient Ingredient { get; set; } = new Ingredient();
        public int Amount { get; set; } = 0;
        public Recipe Recipe { get; set; } = new Recipe();
    }
}
