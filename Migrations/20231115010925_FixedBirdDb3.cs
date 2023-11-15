using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdGame.Migrations
{
    /// <inheritdoc />
    public partial class FixedBirdDb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirdConnectors_UserGames_UserGameId",
                table: "BirdConnectors");

            migrationBuilder.DropIndex(
                name: "IX_BirdConnectors_UserGameId",
                table: "BirdConnectors");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserGames",
                type: "ntext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BirdConnectors",
                type: "ntext",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BirdConnectors_UserId",
                table: "BirdConnectors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BirdConnectors_UserGames_UserId",
                table: "BirdConnectors",
                column: "UserId",
                principalTable: "UserGames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirdConnectors_UserGames_UserId",
                table: "BirdConnectors");

            migrationBuilder.DropIndex(
                name: "IX_BirdConnectors_UserId",
                table: "BirdConnectors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BirdConnectors");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserGames",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ntext")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_BirdConnectors_UserGameId",
                table: "BirdConnectors",
                column: "UserGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_BirdConnectors_UserGames_UserGameId",
                table: "BirdConnectors",
                column: "UserGameId",
                principalTable: "UserGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
