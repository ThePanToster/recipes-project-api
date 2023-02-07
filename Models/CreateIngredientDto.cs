namespace recipes_project_api.Models
{
    public class CreateIngredientDto
    {
        public string Name { get; set; } = String.Empty;
        private string unit;
        public string Unit
        {
            get { return unit; }
            set
            {
                if (value != "sztuki" || value != "ml")
                    unit = "ml";
                else
                    unit = value;
            }
        }
        public double Price { get; set; } = 0.00;
    }
}
