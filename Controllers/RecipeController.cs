using Microsoft.AspNetCore.Mvc;
using recipes_project_api.Models;

namespace recipes_project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var recipes = await _recipeService.GetRecipes();

            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var recipe = await _recipeService.GetById(id);
            if (recipe == null)
                return NotFound();

            return Ok(recipe);
        }

        [HttpGet("{id}/Ingredients")]
        public async Task<IActionResult> GetIngredients(Guid id)
        {
            var ingredients = await _recipeService.GetRecipeIngredients(id);
            if (ingredients == null)
                return NotFound();

            return Ok(ingredients);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeDto createRecipeDto)
        {
            var recipe = await _recipeService.Create(createRecipeDto);
            return Ok(recipe);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRecipeDto updateRecipeDto)
        {
            try
            {
                var recipe = await _recipeService.Update(id, updateRecipeDto);
                return Ok(recipe);
            }
            catch (Exception exception)
            {
                if (exception.Message == "Recipe not found")
                    return NotFound();

                return BadRequest(exception.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _recipeService.Delete(id);

            return NoContent();
        }

    }
}
