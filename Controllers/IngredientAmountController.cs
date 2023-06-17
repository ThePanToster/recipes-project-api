using Microsoft.AspNetCore.Mvc;
using recipes_project_api.Models;

namespace recipes_project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientAmountController : ControllerBase
    {
        private readonly IIngredientAmountService _ingredientAmountService;
        public IngredientAmountController(IIngredientAmountService ingredientAmountService)
        {
            _ingredientAmountService = ingredientAmountService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var ingredientAmount = await _ingredientAmountService.GetById(id);
            if (ingredientAmount == null)
                return NotFound();

            return Ok(ingredientAmount);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIngredientAmountDto createIngredientAmountDto)
        {
            var ingredientAmount = await _ingredientAmountService.Create(createIngredientAmountDto);
            return Ok(ingredientAmount);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateIngredientAmountDto updateIngredientAmountDto)
        {
            try
            {
                var ingredientAmount = await _ingredientAmountService.Update(id, updateIngredientAmountDto);
                return Ok(ingredientAmount);
            }
            catch (Exception exception)
            {
                if (exception.Message == "IngredientAmount not found")
                    return NotFound();

                return BadRequest(exception.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _ingredientAmountService.Delete(id);

            return NoContent();
        }

    }
}
