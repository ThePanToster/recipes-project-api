namespace recipes_project_api.Models
{
    public class CreateIngredientAmountDto
    {
        public string IngredientId { get; set; } = String.Empty;
        public int Amount { get; set; } = 0;
    }
}
