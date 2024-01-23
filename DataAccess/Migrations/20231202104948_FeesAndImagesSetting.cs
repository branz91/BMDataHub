using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FeesAndImagesSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "CoursesList",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FeesList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    LineItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineItemId = table.Column<long>(type: "bigint", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Refunded = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateTimeAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Store = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Transport = table.Column<double>(type: "float", nullable: true),
                    Rent = table.Column<double>(type: "float", nullable: true),
                    Food = table.Column<double>(type: "float", nullable: true),
                    OtherFees = table.Column<double>(type: "float", nullable: true),
                    IdTeacher = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeesList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptImagesList",
                columns: table => new
                {
                    IdKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    FeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptImagesList", x => x.IdKey);
                    table.ForeignKey(
                        name: "FK_ReceiptImagesList_FeesList_FeeId",
                        column: x => x.FeeId,
                        principalTable: "FeesList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptImagesList_FeeId",
                table: "ReceiptImagesList",
                column: "FeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiptImagesList");

            migrationBuilder.DropTable(
                name: "FeesList");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "CoursesList",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
