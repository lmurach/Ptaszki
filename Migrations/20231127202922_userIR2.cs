using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdGame.Migrations
{
    /// <inheritdoc />
    public partial class userIR2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIRs_BasicItems_BasicItemId",
                table: "UserIRs");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIRs_UserGames_UserGameId1",
                table: "UserIRs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIRs",
                table: "UserIRs");

            migrationBuilder.DropIndex(
                name: "IX_UserIRs_UserGameId1",
                table: "UserIRs");

            migrationBuilder.DropColumn(
                name: "UserGameId1",
                table: "UserIRs");

            migrationBuilder.RenameTable(
                name: "UserIRs",
                newName: "UserIR");

            migrationBuilder.RenameIndex(
                name: "IX_UserIRs_BasicItemId",
                table: "UserIR",
                newName: "IX_UserIR_BasicItemId");

            migrationBuilder.AlterColumn<string>(
                name: "UserGameId",
                table: "UserIR",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserIR",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIR",
                table: "UserIR",
                columns: new[] { "UserGameId", "BasicItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserIR_BasicItems_BasicItemId",
                table: "UserIR",
                column: "BasicItemId",
                principalTable: "BasicItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIR_UserGames_UserGameId",
                table: "UserIR",
                column: "UserGameId",
                principalTable: "UserGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserIR_BasicItems_BasicItemId",
                table: "UserIR");

            migrationBuilder.DropForeignKey(
                name: "FK_UserIR_UserGames_UserGameId",
                table: "UserIR");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIR",
                table: "UserIR");

            migrationBuilder.RenameTable(
                name: "UserIR",
                newName: "UserIRs");

            migrationBuilder.RenameIndex(
                name: "IX_UserIR_BasicItemId",
                table: "UserIRs",
                newName: "IX_UserIRs_BasicItemId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserIRs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "UserGameId",
                table: "UserIRs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "UserGameId1",
                table: "UserIRs",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIRs",
                table: "UserIRs",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserIRs_UserGameId1",
                table: "UserIRs",
                column: "UserGameId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserIRs_BasicItems_BasicItemId",
                table: "UserIRs",
                column: "BasicItemId",
                principalTable: "BasicItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserIRs_UserGames_UserGameId1",
                table: "UserIRs",
                column: "UserGameId1",
                principalTable: "UserGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
