namespace recipes_project_api.Models
{
    public class CreateIngredientAmountDto
    {
        public Guid IngredientId { get; set; } = Guid.Empty;
        public int Amount { get; set; } = 0;
    }
}
