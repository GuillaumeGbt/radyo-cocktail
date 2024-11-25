using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cocktail.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionCocktailAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cocktail",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cocktail");
        }
    }
}
