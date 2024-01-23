using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedStructureFeesTab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Refunded",
                table: "FeesList",
                newName: "Validate");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FeesList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "FeesList",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "FeesList");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "FeesList");

            migrationBuilder.RenameColumn(
                name: "Validate",
                table: "FeesList",
                newName: "Refunded");
        }
    }
}
