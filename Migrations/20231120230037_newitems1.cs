using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdGame.Migrations
{
    /// <inheritdoc />
    public partial class newitems1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CraftableItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CraftableItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasicItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CraftableItemId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicItems_CraftableItems_CraftableItemId",
                        column: x => x.CraftableItemId,
                        principalTable: "CraftableItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemRelationships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BuiltItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiredItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiredNum = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRelationships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemRelationships_BasicItems_RequiredItemId",
                        column: x => x.RequiredItemId,
                        principalTable: "BasicItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemRelationships_CraftableItems_BuiltItemId",
                        column: x => x.BuiltItemId,
                        principalTable: "CraftableItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasicItems_CraftableItemId",
                table: "BasicItems",
                column: "CraftableItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRelationships_BuiltItemId",
                table: "ItemRelationships",
                column: "BuiltItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRelationships_RequiredItemId",
                table: "ItemRelationships",
                column: "RequiredItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemRelationships");

            migrationBuilder.DropTable(
                name: "BasicItems");

            migrationBuilder.DropTable(
                name: "CraftableItems");
        }
    }
}
