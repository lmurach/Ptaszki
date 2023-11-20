using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdGame.Migrations
{
    /// <inheritdoc />
    public partial class newitems2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRelationships_BasicItems_RequiredItemId",
                table: "ItemRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRelationships_CraftableItems_BuiltItemId",
                table: "ItemRelationships");

            migrationBuilder.RenameColumn(
                name: "RequiredItemId",
                table: "ItemRelationships",
                newName: "CraftableItemId");

            migrationBuilder.RenameColumn(
                name: "BuiltItemId",
                table: "ItemRelationships",
                newName: "BasicItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRelationships_RequiredItemId",
                table: "ItemRelationships",
                newName: "IX_ItemRelationships_CraftableItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRelationships_BuiltItemId",
                table: "ItemRelationships",
                newName: "IX_ItemRelationships_BasicItemId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemRelationships_BasicItems_BasicItemId",
                table: "ItemRelationships");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemRelationships_CraftableItems_CraftableItemId",
                table: "ItemRelationships");

            migrationBuilder.RenameColumn(
                name: "CraftableItemId",
                table: "ItemRelationships",
                newName: "RequiredItemId");

            migrationBuilder.RenameColumn(
                name: "BasicItemId",
                table: "ItemRelationships",
                newName: "BuiltItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRelationships_CraftableItemId",
                table: "ItemRelationships",
                newName: "IX_ItemRelationships_RequiredItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemRelationships_BasicItemId",
                table: "ItemRelationships",
                newName: "IX_ItemRelationships_BuiltItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRelationships_BasicItems_RequiredItemId",
                table: "ItemRelationships",
                column: "RequiredItemId",
                principalTable: "BasicItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemRelationships_CraftableItems_BuiltItemId",
                table: "ItemRelationships",
                column: "BuiltItemId",
                principalTable: "CraftableItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
