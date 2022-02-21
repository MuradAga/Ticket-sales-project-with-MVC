using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursProjectLast.Migrations
{
    public partial class delete_column_Address_Email_Phone_from_Airline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirlineAddress",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "AirlineEmail",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "AirlinePhone",
                table: "Airlines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AirlineAddress",
                table: "Airlines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AirlineEmail",
                table: "Airlines",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AirlinePhone",
                table: "Airlines",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
