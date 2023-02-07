using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipesprojectapi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRecipeIngredientRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmounts_Recipes_RecipeId",
                table: "IngredientAmounts");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "IngredientAmounts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmounts_Recipes_RecipeId",
                table: "IngredientAmounts",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmounts_Recipes_RecipeId",
                table: "IngredientAmounts");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "IngredientAmounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmounts_Recipes_RecipeId",
                table: "IngredientAmounts",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
