using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdGame.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreBirdDbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rolledSSBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    BirdId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolledSSBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rolledSSBs_Birds_BirdId",
                        column: x => x.BirdId,
                        principalTable: "Birds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rolledSSBs_UserGames_UserId",
                        column: x => x.UserId,
                        principalTable: "UserGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sideShopBirds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Star = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    BirdId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sideShopBirds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sideShopBirds_Birds_BirdId",
                        column: x => x.BirdId,
                        principalTable: "Birds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sideShopBirds_UserGames_UserId",
                        column: x => x.UserId,
                        principalTable: "UserGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rolledSSBs_BirdId",
                table: "rolledSSBs",
                column: "BirdId");

            migrationBuilder.CreateIndex(
                name: "IX_rolledSSBs_UserId",
                table: "rolledSSBs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_sideShopBirds_BirdId",
                table: "sideShopBirds",
                column: "BirdId");

            migrationBuilder.CreateIndex(
                name: "IX_sideShopBirds_UserId",
                table: "sideShopBirds",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rolledSSBs");

            migrationBuilder.DropTable(
                name: "sideShopBirds");
        }
    }
}
