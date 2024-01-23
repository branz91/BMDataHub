using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewColumnsFees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Food",
                table: "CoursesList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OtherFees",
                table: "CoursesList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rent",
                table: "CoursesList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Transport",
                table: "CoursesList",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Food",
                table: "CoursesList");

            migrationBuilder.DropColumn(
                name: "OtherFees",
                table: "CoursesList");

            migrationBuilder.DropColumn(
                name: "Rent",
                table: "CoursesList");

            migrationBuilder.DropColumn(
                name: "Transport",
                table: "CoursesList");
        }
    }
}
