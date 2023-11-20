using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdGame.Migrations
{
    /// <inheritdoc />
    public partial class FixedBirdDb7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RarityUpgrade",
                table: "UserGames",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RarityUpgrade",
                table: "UserGames");
        }
    }
}
