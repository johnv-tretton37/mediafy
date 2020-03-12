using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontendAssignment.Migrations
{
    public partial class UrlSegment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlSegment",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlSegment",
                table: "Products");
        }
    }
}
