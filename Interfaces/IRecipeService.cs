﻿using recipes_project_api.Models;

namespace recipes_project_api.Interfaces
{
    public interface IRecipeService
    {
        Task<List<IngredientAmount>> GetRecipeIngredients(Guid recipeId);
        Task<List<Recipe>> GetRecipes();
        Task<Recipe> GetById(Guid recipeId);
        Task<Recipe> Create(CreateRecipeDto dto);
        Task<Recipe> Update(Guid recipeId, UpdateRecipeDto dto);
        Task Delete(Guid recipeId);
    }
}
