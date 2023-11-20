using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdGame.Migrations
{
    /// <inheritdoc />
    public partial class FixedBirdDb8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGameId",
                table: "BirdConnectors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserGameId",
                table: "BirdConnectors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
