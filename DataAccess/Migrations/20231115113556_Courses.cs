using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Courses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoursesList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    LineItemTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineItemId = table.Column<long>(type: "bigint", nullable: true),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    newcomer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LineItemPrice = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<byte>(type: "tinyint", nullable: true),
                    Refunded = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SalesChannel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateTimeAdded = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Store = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    consent = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesList", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesList");
        }
    }
}
