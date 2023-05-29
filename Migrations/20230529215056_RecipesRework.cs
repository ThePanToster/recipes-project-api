using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipesprojectapi.Migrations
{
    /// <inheritdoc />
    public partial class RecipesRework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmounts_Recipes_RecipeId",
                table: "IngredientAmounts");

            migrationBuilder.DropIndex(
                name: "IX_IngredientAmounts_RecipeId",
                table: "IngredientAmounts");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "IngredientAmounts");

            migrationBuilder.AddColumn<List<Guid>>(
                name: "IngredientAmount",
                table: "Recipes",
                type: "uuid[]",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientAmount",
                table: "Recipes");

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeId",
                table: "IngredientAmounts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientAmounts_RecipeId",
                table: "IngredientAmounts",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmounts_Recipes_RecipeId",
                table: "IngredientAmounts",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
