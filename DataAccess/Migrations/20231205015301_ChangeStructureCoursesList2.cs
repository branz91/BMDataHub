using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStructureCoursesList2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Food",
                table: "FeesList");

            migrationBuilder.DropColumn(
                name: "OtherFees",
                table: "FeesList");

            migrationBuilder.DropColumn(
                name: "Rent",
                table: "FeesList");

            migrationBuilder.DropColumn(
                name: "Transport",
                table: "FeesList");

            migrationBuilder.RenameColumn(
                name: "Fees",
                table: "CoursesList",
                newName: "FeesAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeesAmount",
                table: "CoursesList",
                newName: "Fees");

            migrationBuilder.AddColumn<double>(
                name: "Food",
                table: "FeesList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OtherFees",
                table: "FeesList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rent",
                table: "FeesList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Transport",
                table: "FeesList",
                type: "float",
                nullable: true);
        }
    }
}
