using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursProjectLast.Migrations
{
    public partial class delete_column_LogoPath_from_Airline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoPath",
                table: "Airlines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogoPath",
                table: "Airlines",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
