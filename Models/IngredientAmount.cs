using System.ComponentModel.DataAnnotations;

namespace recipes_project_api.Models
{
    public class IngredientAmount
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid IngredientId { get; set; } = Guid.Empty;
        public int Amount { get; set; } = 0;
    }
}
