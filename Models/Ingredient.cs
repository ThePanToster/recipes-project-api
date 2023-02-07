using System.ComponentModel.DataAnnotations;

namespace recipes_project_api.Models
{
    public class Ingredient
    {
        [Required]
        public Guid Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; } = String.Empty;
        public bool IsUncountable { get; set; } = true;
        public double Price { get; set; } = 0.0;
    }
}
