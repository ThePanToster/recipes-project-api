using Microsoft.EntityFrameworkCore;
using recipes_project_api.Models;

namespace recipes_project_api.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly Context _context;
        public RecipeService(Context context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            return await _context.Recipes.ToListAsync();
        }
        public async Task<Recipe> GetById(Guid recipeId)
        {
            var recipe = await _context.Recipes.SingleOrDefaultAsync(x => x.Id == recipeId);
            if (recipe == null)
                throw new Exception("Recipe not found");

            return recipe;
        }
        public async Task<List<IngredientAmount>> GetRecipeIngredients(Guid recipeId)
        {
            var recipe = await GetById(recipeId);
            return recipe.IngredientAmount;
        }
        public async Task<Recipe> Create(CreateRecipeDto dto)
        {
            var recipe = new Recipe
            {
                Name = dto.Name,
                Description = dto.Description,
                IngredientAmount = dto.IngredientAmount,
            };

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }
        public async Task<Recipe> Update(Guid recipeId, UpdateRecipeDto dto)
        {
            var recipe = await GetById(recipeId);

            if (recipe == null)
                throw new Exception("Recipe not found");

            if (dto.Name == null && dto.Description == null && dto.IngredientAmount == null)
                throw new Exception("You must update at least one property.");

            if (dto.Name != null)
                recipe.Name = dto.Name;

            if (dto.Description != null)
                recipe.Description = dto.Description;

            if (dto.IngredientAmount != null)
                recipe.IngredientAmount = dto.IngredientAmount;

            await _context.SaveChangesAsync();

            return recipe;

        }

        public async Task Delete(Guid recipeId)
        {
            _context.Recipes.Remove(await GetById(recipeId));
            await _context.SaveChangesAsync();
        }

    }
}
