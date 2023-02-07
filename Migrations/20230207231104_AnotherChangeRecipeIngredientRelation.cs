using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipesprojectapi.Migrations
{
    /// <inheritdoc />
    public partial class AnotherChangeRecipeIngredientRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmounts_Ingredients_IngredientId",
                table: "IngredientAmounts");

            migrationBuilder.DropIndex(
                name: "IX_IngredientAmounts_IngredientId",
                table: "IngredientAmounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_IngredientAmounts_IngredientId",
                table: "IngredientAmounts",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmounts_Ingredients_IngredientId",
                table: "IngredientAmounts",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
