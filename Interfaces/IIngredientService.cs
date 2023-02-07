using recipes_project_api.Models;

namespace recipes_project_api.Interfaces
{
    public interface IIngredientService
    {
        Task<List<Ingredient>> GetIngredients();
        Task<Ingredient> GetById(Guid ingredientId);
        Task<Ingredient> Create(CreateIngredientDto dto);
        Task<Ingredient> Update(Guid ingredientId, UpdateIngredientDto dto);
        Task Delete(Guid ingredientId);
    }
}
