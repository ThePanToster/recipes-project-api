namespace recipes_project_api.Models
{
    public class CreateIngredientAmountDto
    {
        public Ingredient Ingredient { get; set; } = new Ingredient();
        public int Amount { get; set; } = 0;
        public Recipe? Recipe { get; set; } = new Recipe();
    }
}
