using Microsoft.EntityFrameworkCore;
using recipes_project_api.Models;

namespace recipes_project_api.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly Context _context;
        public IngredientService(Context context)
        {
            _context = context;
        }

        public async Task<List<Ingredient>> GetIngredients()
        {
            return await _context.Ingredients.ToListAsync();
        }
        public async Task<Ingredient> GetById(Guid ingredientId)
        {
            var ingredient = await _context.Ingredients.SingleOrDefaultAsync(x => x.Id == ingredientId);
            if (ingredient == null)
                throw new Exception("Ingredient not found");

            return ingredient;
        }

        public async Task<Ingredient> Create(CreateIngredientDto dto)
        {
            var ingredient = new Ingredient
            {
                Name = dto.Name,
                Unit = dto.Unit,
                Price = dto.Price,
            };

            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return ingredient;
        }
        public async Task<Ingredient> Update(Guid ingredientId, UpdateIngredientDto dto)
        {
            var ingredient = await GetById(ingredientId);

            if (ingredient == null)
                throw new Exception("Ingredient not found");

            if (dto.Name == null && dto.Unit == null && dto.Price == null)
                throw new Exception("You must update at least one property.");

            if (dto.Name != null)
                ingredient.Name = dto.Name;

            if (dto.Unit != null)
                ingredient.Unit = dto.Unit;

            if (dto.Price != null)
                ingredient.Price = (double)dto.Price;

            await _context.SaveChangesAsync();

            return ingredient;

        }

        public async Task Delete(Guid ingredientId)
        {
            _context.Ingredients.Remove(await GetById(ingredientId));
            await _context.SaveChangesAsync();
        }

    }
}
