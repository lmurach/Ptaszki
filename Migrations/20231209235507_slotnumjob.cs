using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdGame.Migrations
{
    /// <inheritdoc />
    public partial class slotnumjob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "jobTitle",
                table: "jobBirds",
                newName: "JobTitle");

            migrationBuilder.AddColumn<int>(
                name: "SlotNum",
                table: "jobBirds",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlotNum",
                table: "jobBirds");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "jobBirds",
                newName: "jobTitle");
        }
    }
}
