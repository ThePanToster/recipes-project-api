using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipesprojectapi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIngredientUnitToBool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Ingredients");

            migrationBuilder.AddColumn<bool>(
                name: "IsUncountable",
                table: "Ingredients",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUncountable",
                table: "Ingredients");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Ingredients",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
