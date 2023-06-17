using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace recipesprojectapi.Migrations
{
    /// <inheritdoc />
    public partial class AnotherIngredientAmountChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmount_Recipes_RecipeId",
                table: "IngredientAmount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientAmount",
                table: "IngredientAmount");

            migrationBuilder.RenameTable(
                name: "IngredientAmount",
                newName: "IngredientAmounts");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientAmount_RecipeId",
                table: "IngredientAmounts",
                newName: "IX_IngredientAmounts_RecipeId");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "IngredientAmounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientAmounts",
                table: "IngredientAmounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmounts_Recipes_RecipeId",
                table: "IngredientAmounts",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientAmounts_Recipes_RecipeId",
                table: "IngredientAmounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientAmounts",
                table: "IngredientAmounts");

            migrationBuilder.RenameTable(
                name: "IngredientAmounts",
                newName: "IngredientAmount");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientAmounts_RecipeId",
                table: "IngredientAmount",
                newName: "IX_IngredientAmount_RecipeId");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "IngredientAmount",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientAmount",
                table: "IngredientAmount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientAmount_Recipes_RecipeId",
                table: "IngredientAmount",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
