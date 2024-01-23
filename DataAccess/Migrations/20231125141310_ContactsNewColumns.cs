using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ContactsNewColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SharingBMInt",
                table: "ContactsList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SharingCountry",
                table: "ContactsList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SharingTeachers",
                table: "ContactsList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalCourses",
                table: "ContactsList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalFees",
                table: "ContactsList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalIncome",
                table: "ContactsList",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalStudents",
                table: "ContactsList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalTeachers",
                table: "ContactsList",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SharingBMInt",
                table: "ContactsList");

            migrationBuilder.DropColumn(
                name: "SharingCountry",
                table: "ContactsList");

            migrationBuilder.DropColumn(
                name: "SharingTeachers",
                table: "ContactsList");

            migrationBuilder.DropColumn(
                name: "TotalCourses",
                table: "ContactsList");

            migrationBuilder.DropColumn(
                name: "TotalFees",
                table: "ContactsList");

            migrationBuilder.DropColumn(
                name: "TotalIncome",
                table: "ContactsList");

            migrationBuilder.DropColumn(
                name: "TotalStudents",
                table: "ContactsList");

            migrationBuilder.DropColumn(
                name: "TotalTeachers",
                table: "ContactsList");
        }
    }
}
