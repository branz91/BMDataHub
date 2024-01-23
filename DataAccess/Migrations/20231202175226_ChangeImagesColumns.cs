using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImagesColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeeName",
                table: "ReceiptImagesList");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ReceiptImagesList");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ReceiptImagesList");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiptImageUrl",
                table: "ReceiptImagesList",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReceiptImageUrl",
                table: "ReceiptImagesList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeeName",
                table: "ReceiptImagesList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ReceiptImagesList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "ReceiptImagesList",
                type: "bigint",
                nullable: true);
        }
    }
}
