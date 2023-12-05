using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdGame.Migrations
{
    /// <inheritdoc />
    public partial class userIR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserIRs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserGameId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserGameId1 = table.Column<string>(type: "text", nullable: false),
                    BasicItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnedNum = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIRs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserIRs_BasicItems_BasicItemId",
                        column: x => x.BasicItemId,
                        principalTable: "BasicItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserIRs_UserGames_UserGameId1",
                        column: x => x.UserGameId1,
                        principalTable: "UserGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserIRs_BasicItemId",
                table: "UserIRs",
                column: "BasicItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIRs_UserGameId1",
                table: "UserIRs",
                column: "UserGameId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserIRs");
        }
    }
}
