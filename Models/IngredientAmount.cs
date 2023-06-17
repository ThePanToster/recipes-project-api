using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace recipes_project_api.Models
{
    public class IngredientAmount
    {
        public Guid Id { get; set; }
        public string IngredientId { get; set; } = String.Empty;
        public int Amount { get; set; } = 0;
        public Guid RecipeId { get; set; } = Guid.Empty;
    }
}
