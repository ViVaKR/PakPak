using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BootCamp.Migrations
{
    /// <inheritdoc />
    public partial class CreatenewmodelsAsciiCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsciiCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Dec = table.Column<int>(type: "int", nullable: false),
                    Oct = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Hex = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Bin = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HtmlNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    HtmlName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsciiCodes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsciiCodes");
        }
    }
}
