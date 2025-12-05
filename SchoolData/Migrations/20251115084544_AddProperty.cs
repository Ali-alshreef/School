using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolData.Migrations
{
    /// <inheritdoc />
    public partial class AddProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ColmunValue",
                table: "LogEntries",
                newName: "OldValue");

            migrationBuilder.AddColumn<string>(
                name: "NewValue",
                table: "LogEntries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewValue",
                table: "LogEntries");

            migrationBuilder.RenameColumn(
                name: "OldValue",
                table: "LogEntries",
                newName: "ColmunValue");
        }
    }
}
