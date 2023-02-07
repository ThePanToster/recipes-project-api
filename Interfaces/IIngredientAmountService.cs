using recipes_project_api.Models;

namespace recipes_project_api.Interfaces
{
    public interface IIngredientAmountService
    {
        Task<IngredientAmount> GetById(Guid ingredientAmountId);
        Task<IngredientAmount> Create(CreateIngredientAmountDto dto);
        Task<IngredientAmount> Update(Guid ingredientAmountId, UpdateIngredientAmountDto dto);
        Task Delete(Guid ingredientAmountId);
    }
}
