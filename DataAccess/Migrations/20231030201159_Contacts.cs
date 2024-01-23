using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Contacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactsList",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spiritual_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_of_residence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_calculated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hs_language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    do_you_speak_english_ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender__ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_of_birth_date_picker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobilephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verified_art_teacher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verified_knowledge_teachers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verified_music = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verified_rituals_teacher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verified_yoga_and_meditation_teachers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verified_aky_teacher = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactsList", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactsList");
        }
    }
}
