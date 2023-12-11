using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdGame.Migrations
{
    /// <inheritdoc />
    public partial class dailyyield4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yields_BasicItems_BasicItemId",
                table: "Yields");

            migrationBuilder.RenameColumn(
                name: "BasicItemId",
                table: "Yields",
                newName: "BirdId");

            migrationBuilder.RenameIndex(
                name: "IX_Yields_BasicItemId",
                table: "Yields",
                newName: "IX_Yields_BirdId");

            migrationBuilder.AddColumn<string>(
                name: "BasicItemName",
                table: "Yields",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobAssociation",
                table: "BasicItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "rarity",
                table: "BasicItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Yields_Birds_BirdId",
                table: "Yields",
                column: "BirdId",
                principalTable: "Birds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yields_Birds_BirdId",
                table: "Yields");

            migrationBuilder.DropColumn(
                name: "BasicItemName",
                table: "Yields");

            migrationBuilder.DropColumn(
                name: "JobAssociation",
                table: "BasicItems");

            migrationBuilder.DropColumn(
                name: "rarity",
                table: "BasicItems");

            migrationBuilder.RenameColumn(
                name: "BirdId",
                table: "Yields",
                newName: "BasicItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Yields_BirdId",
                table: "Yields",
                newName: "IX_Yields_BasicItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yields_BasicItems_BasicItemId",
                table: "Yields",
                column: "BasicItemId",
                principalTable: "BasicItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
