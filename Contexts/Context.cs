using Microsoft.EntityFrameworkCore;
using recipes_project_api.Models;

namespace recipes_project_api.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientAmount> IngredientAmounts { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
    }
}
