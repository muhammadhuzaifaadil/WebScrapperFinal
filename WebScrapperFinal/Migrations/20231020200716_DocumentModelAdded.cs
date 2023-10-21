using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebScrapperFinal.Migrations
{
    /// <inheritdoc />
    public partial class DocumentModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Document",
                table: "UniversityCourses");

            migrationBuilder.DropColumn(
                name: "Fees",
                table: "UniversityCourses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "UniversityCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fees",
                table: "UniversityCourses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
