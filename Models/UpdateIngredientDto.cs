namespace recipes_project_api.Models
{
    public class UpdateIngredientDto
    {
        public string? Name { get; set; }
        public double? Price { get; set; }
        private string? unit;
        public string? Unit
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
        
    }
}
