using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdGame.Migrations
{
    /// <inheritdoc />
    public partial class namechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rolledSSBs_Birds_BirdId",
                table: "rolledSSBs");

            migrationBuilder.DropForeignKey(
                name: "FK_rolledSSBs_UserGames_UserId",
                table: "rolledSSBs");

            migrationBuilder.DropForeignKey(
                name: "FK_sideShopBirds_Birds_BirdId",
                table: "sideShopBirds");

            migrationBuilder.DropForeignKey(
                name: "FK_sideShopBirds_UserGames_UserId",
                table: "sideShopBirds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sideShopBirds",
                table: "sideShopBirds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rolledSSBs",
                table: "rolledSSBs");

            migrationBuilder.RenameTable(
                name: "sideShopBirds",
                newName: "SideShopBirds");

            migrationBuilder.RenameTable(
                name: "rolledSSBs",
                newName: "RolledSSBs");

            migrationBuilder.RenameIndex(
                name: "IX_sideShopBirds_UserId",
                table: "SideShopBirds",
                newName: "IX_SideShopBirds_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_sideShopBirds_BirdId",
                table: "SideShopBirds",
                newName: "IX_SideShopBirds_BirdId");

            migrationBuilder.RenameIndex(
                name: "IX_rolledSSBs_UserId",
                table: "RolledSSBs",
                newName: "IX_RolledSSBs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_rolledSSBs_BirdId",
                table: "RolledSSBs",
                newName: "IX_RolledSSBs_BirdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SideShopBirds",
                table: "SideShopBirds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolledSSBs",
                table: "RolledSSBs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RolledSSBs_Birds_BirdId",
                table: "RolledSSBs",
                column: "BirdId",
                principalTable: "Birds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolledSSBs_UserGames_UserId",
                table: "RolledSSBs",
                column: "UserId",
                principalTable: "UserGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SideShopBirds_Birds_BirdId",
                table: "SideShopBirds",
                column: "BirdId",
                principalTable: "Birds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SideShopBirds_UserGames_UserId",
                table: "SideShopBirds",
                column: "UserId",
                principalTable: "UserGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolledSSBs_Birds_BirdId",
                table: "RolledSSBs");

            migrationBuilder.DropForeignKey(
                name: "FK_RolledSSBs_UserGames_UserId",
                table: "RolledSSBs");

            migrationBuilder.DropForeignKey(
                name: "FK_SideShopBirds_Birds_BirdId",
                table: "SideShopBirds");

            migrationBuilder.DropForeignKey(
                name: "FK_SideShopBirds_UserGames_UserId",
                table: "SideShopBirds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SideShopBirds",
                table: "SideShopBirds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolledSSBs",
                table: "RolledSSBs");

            migrationBuilder.RenameTable(
                name: "SideShopBirds",
                newName: "sideShopBirds");

            migrationBuilder.RenameTable(
                name: "RolledSSBs",
                newName: "rolledSSBs");

            migrationBuilder.RenameIndex(
                name: "IX_SideShopBirds_UserId",
                table: "sideShopBirds",
                newName: "IX_sideShopBirds_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SideShopBirds_BirdId",
                table: "sideShopBirds",
                newName: "IX_sideShopBirds_BirdId");

            migrationBuilder.RenameIndex(
                name: "IX_RolledSSBs_UserId",
                table: "rolledSSBs",
                newName: "IX_rolledSSBs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RolledSSBs_BirdId",
                table: "rolledSSBs",
                newName: "IX_rolledSSBs_BirdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sideShopBirds",
                table: "sideShopBirds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rolledSSBs",
                table: "rolledSSBs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_rolledSSBs_Birds_BirdId",
                table: "rolledSSBs",
                column: "BirdId",
                principalTable: "Birds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rolledSSBs_UserGames_UserId",
                table: "rolledSSBs",
                column: "UserId",
                principalTable: "UserGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sideShopBirds_Birds_BirdId",
                table: "sideShopBirds",
                column: "BirdId",
                principalTable: "Birds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sideShopBirds_UserGames_UserId",
                table: "sideShopBirds",
                column: "UserId",
                principalTable: "UserGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
