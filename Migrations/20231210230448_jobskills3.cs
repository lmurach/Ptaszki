using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdGame.Migrations
{
    /// <inheritdoc />
    public partial class jobskills3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JS_BugFinder",
                table: "jobBirds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JS_FeatherFeatcher",
                table: "jobBirds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JS_Gatherer",
                table: "jobBirds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JS_Hunter",
                table: "jobBirds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JS_RockBreaker",
                table: "jobBirds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JS_SeedCollector",
                table: "jobBirds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JS_BugFinder",
                table: "jobBirds");

            migrationBuilder.DropColumn(
                name: "JS_FeatherFeatcher",
                table: "jobBirds");

            migrationBuilder.DropColumn(
                name: "JS_Gatherer",
                table: "jobBirds");

            migrationBuilder.DropColumn(
                name: "JS_Hunter",
                table: "jobBirds");

            migrationBuilder.DropColumn(
                name: "JS_RockBreaker",
                table: "jobBirds");

            migrationBuilder.DropColumn(
                name: "JS_SeedCollector",
                table: "jobBirds");
        }
    }
}
