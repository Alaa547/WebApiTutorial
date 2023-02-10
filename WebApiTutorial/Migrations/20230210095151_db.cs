using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiTutorial.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonCategories_PokemonCategories_PokemonCategoryPokemonId_PokemonCategoryCategoryId",
                table: "PokemonCategories");

            migrationBuilder.DropIndex(
                name: "IX_PokemonCategories_PokemonCategoryPokemonId_PokemonCategoryCategoryId",
                table: "PokemonCategories");

            migrationBuilder.DropColumn(
                name: "PokemonCategoryCategoryId",
                table: "PokemonCategories");

            migrationBuilder.DropColumn(
                name: "PokemonCategoryPokemonId",
                table: "PokemonCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PokemonCategoryCategoryId",
                table: "PokemonCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PokemonCategoryPokemonId",
                table: "PokemonCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCategories_PokemonCategoryPokemonId_PokemonCategoryCategoryId",
                table: "PokemonCategories",
                columns: new[] { "PokemonCategoryPokemonId", "PokemonCategoryCategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonCategories_PokemonCategories_PokemonCategoryPokemonId_PokemonCategoryCategoryId",
                table: "PokemonCategories",
                columns: new[] { "PokemonCategoryPokemonId", "PokemonCategoryCategoryId" },
                principalTable: "PokemonCategories",
                principalColumns: new[] { "PokemonId", "CategoryId" });
        }
    }
}
