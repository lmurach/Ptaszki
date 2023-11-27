using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdGame.Migrations
{
    /// <inheritdoc />
    public partial class itemdbmanual1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasicItems_CraftableItems_CraftableItemId",
                table: "BasicItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRelationships_BasicItems_BasicItemId",
                table: "ItemRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRelationships_CraftableItems_CraftableItemId",
                table: "ItemRelationships");

            migrationBuilder.DropIndex(
                name: "IX_BasicItems_CraftableItemId",
                table: "BasicItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemRelationships",
                table: "ItemRelationships");

            migrationBuilder.DropIndex(
                name: "IX_ItemRelationships_BasicItemId",
                table: "ItemRelationships");

            migrationBuilder.DropColumn(
                name: "CraftableItemId",
                table: "BasicItems");

            migrationBuilder.RenameTable(
                name: "ItemRelationships",
                newName: "ItemRelationship");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRelationships_CraftableItemId",
                table: "ItemRelationship",
                newName: "IX_ItemRelationship_CraftableItemId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ItemRelationship",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemRelationship",
                table: "ItemRelationship",
                columns: new[] { "BasicItemId", "CraftableItemId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRelationship_BasicItems_BasicItemId",
                table: "ItemRelationship",
                column: "BasicItemId",
                principalTable: "BasicItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRelationship_CraftableItems_CraftableItemId",
                table: "ItemRelationship",
                column: "CraftableItemId",
                principalTable: "CraftableItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRelationship_BasicItems_BasicItemId",
                table: "ItemRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRelationship_CraftableItems_CraftableItemId",
                table: "ItemRelationship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemRelationship",
                table: "ItemRelationship");

            migrationBuilder.RenameTable(
                name: "ItemRelationship",
                newName: "ItemRelationships");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRelationship_CraftableItemId",
                table: "ItemRelationships",
                newName: "IX_ItemRelationships_CraftableItemId");

            migrationBuilder.AddColumn<int>(
                name: "CraftableItemId",
                table: "BasicItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ItemRelationships",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemRelationships",
                table: "ItemRelationships",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BasicItems_CraftableItemId",
                table: "BasicItems",
                column: "CraftableItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRelationships_BasicItemId",
                table: "ItemRelationships",
                column: "BasicItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasicItems_CraftableItems_CraftableItemId",
                table: "BasicItems",
                column: "CraftableItemId",
                principalTable: "CraftableItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRelationships_BasicItems_BasicItemId",
                table: "ItemRelationships",
                column: "BasicItemId",
                principalTable: "BasicItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRelationships_CraftableItems_CraftableItemId",
                table: "ItemRelationships",
                column: "CraftableItemId",
                principalTable: "CraftableItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
