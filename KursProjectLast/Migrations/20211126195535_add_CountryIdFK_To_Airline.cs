using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursProjectLast.Migrations
{
    public partial class add_CountryIdFK_To_Airline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Airlines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Airlines_CountryId",
                table: "Airlines",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Airlines_Countries_CountryId",
                table: "Airlines",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airlines_Countries_CountryId",
                table: "Airlines");

            migrationBuilder.DropIndex(
                name: "IX_Airlines_CountryId",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Airlines");
        }
    }
}
