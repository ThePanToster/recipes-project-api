using Microsoft.EntityFrameworkCore;
using recipes_project_api.Models;
using System.Linq;

namespace recipes_project_api.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly Context _context;
        public RecipeService(Context context)
        {
            _context = context;
        }
        public async Task<List<IngredientAmount>> GetRecipeIngredients(Guid recipeId)
        {
            return _context.IngredientAmounts
                .Where(x => x.RecipeId == recipeId)
                .ToList();
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            var recipeList = await _context.Recipes.ToListAsync();

            recipeList.ForEach(async x => x.IngredientList = await GetRecipeIngredients(x.Id));

            return recipeList;
        }

        public async Task<Recipe> GetById(Guid recipeId)
        {
            var recipe = await _context.Recipes.SingleOrDefaultAsync(x => x.Id == recipeId);

            if (recipe == null)
                throw new Exception("Recipe not found");
            else
                recipe.IngredientList = await GetRecipeIngredients(recipeId);

            return recipe;
        }

        public async Task<Recipe> Create(CreateRecipeDto dto)
        {
            var recipe = new Recipe
            {
                Name = dto.Name,
                Description = dto.Description,
                IngredientList = dto.IngredientList,
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

            if (dto.Name == null && dto.Description == null && dto.IngredientList == null)
                throw new Exception("You must update at least one property.");

            if (dto.Name != null)
                recipe.Name = dto.Name;

            if (dto.Description != null)
                recipe.Description = dto.Description;

            if (dto.IngredientList != null)
                recipe.IngredientList = dto.IngredientList;

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
