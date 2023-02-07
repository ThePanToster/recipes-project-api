namespace recipes_project_api.Models
{
    public class UpdateIngredientAmountDto
    {
        public Guid? IngredientId { get; set; }
        public int? Amount { get; set; }
    }
}
