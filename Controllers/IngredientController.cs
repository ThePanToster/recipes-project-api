using Microsoft.AspNetCore.Mvc;
using recipes_project_api.Models;

namespace recipes_project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ingredients = await _ingredientService.GetIngredients();

            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var ingredient = await _ingredientService.GetById(id);
            if (ingredient == null)
                return NotFound();

            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIngredientDto createIngredientDto)
        {
            var ingredient = await _ingredientService.Create(createIngredientDto);
            return Ok(ingredient);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateIngredientDto updateIngredientDto)
        {
            try
            {
                var ingredient = await _ingredientService.Update(id, updateIngredientDto);
                return Ok(ingredient);
            }
            catch (Exception exception)
            {
                if (exception.Message == "Ingredient not found")
                    return NotFound();

                return BadRequest(exception.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _ingredientService.Delete(id);

            return NoContent();
        }

    }
}
