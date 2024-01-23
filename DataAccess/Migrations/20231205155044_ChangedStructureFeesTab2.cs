using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedStructureFeesTab2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "FeesList");

            migrationBuilder.DropColumn(
                name: "DateTimeAdded",
                table: "FeesList");

            migrationBuilder.DropColumn(
                name: "LineItemId",
                table: "FeesList");

            migrationBuilder.DropColumn(
                name: "LineItemTitle",
                table: "FeesList");

            migrationBuilder.DropColumn(
                name: "OrderName",
                table: "FeesList");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "FeesList");

            migrationBuilder.DropColumn(
                name: "Store",
                table: "FeesList");

            migrationBuilder.AlterColumn<bool>(
                name: "Validate",
                table: "FeesList",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Validate",
                table: "FeesList",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "FeesList",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeAdded",
                table: "FeesList",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LineItemId",
                table: "FeesList",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LineItemTitle",
                table: "FeesList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderName",
                table: "FeesList",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "FeesList",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Store",
                table: "FeesList",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
