using Microsoft.EntityFrameworkCore;
using recipes_project_api.Models;

namespace recipes_project_api.Services
{
    public class IngredientAmountService : IIngredientAmountService
    {
        private readonly Context _context;
        public IngredientAmountService(Context context)
        {
            _context = context;
        }
        public async Task<IngredientAmount> GetById(Guid ingredientAmountId)
        {
            var ingredientAmount = await _context.IngredientAmounts.SingleOrDefaultAsync(x => x.Id == ingredientAmountId);
            if (ingredientAmount == null)
                throw new Exception("IngredientAmount not found");

            return ingredientAmount;
        }
        public async Task<IngredientAmount> Create(CreateIngredientAmountDto dto)
        {
            var ingredientAmount = new IngredientAmount
            {
                IngredientId = dto.IngredientId,
                Amount = dto.Amount,
            };

            _context.IngredientAmounts.Add(ingredientAmount);
            await _context.SaveChangesAsync();
            return ingredientAmount;
        }
        public async Task<IngredientAmount> Update(Guid ingredientAmountId, UpdateIngredientAmountDto dto)
        {
            var ingredientAmount = await GetById(ingredientAmountId);

            if (ingredientAmount == null)
                throw new Exception("IngredientAmount not found");

            if (dto.IngredientId == null && dto.Amount == null)
                throw new Exception("You must update at least one property.");

            if (dto.IngredientId != null)
                ingredientAmount.IngredientId = dto.IngredientId;

            if (dto.Amount != null)
                ingredientAmount.Amount = (int)dto.Amount;

            await _context.SaveChangesAsync();

            return ingredientAmount;

        }

        public async Task Delete(Guid ingredientAmountId)
        {
            _context.IngredientAmounts.Remove(await GetById(ingredientAmountId));
            await _context.SaveChangesAsync();
        }

    }
}
