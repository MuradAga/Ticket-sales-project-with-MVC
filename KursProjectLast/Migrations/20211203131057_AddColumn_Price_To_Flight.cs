using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursProjectLast.Migrations
{
    public partial class AddColumn_Price_To_Flight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Flights",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Flights");
        }
    }
}
