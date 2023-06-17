using System.ComponentModel.DataAnnotations;

namespace recipes_project_api.Models
{
    public class IngredientAmount
    {
        [Required]
        public Guid Id { get; set; }
        [MaxLength(38)]
        public string IngredientId { get; set; } = String.Empty;
        public int Amount { get; set; } = 0;
    }
}
