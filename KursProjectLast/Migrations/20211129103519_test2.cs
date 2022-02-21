using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KursProjectLast.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airplanes_AirplaneId",
                table: "Flights");

            migrationBuilder.DropTable(
                name: "Airplanes");

            migrationBuilder.RenameColumn(
                name: "AirplaneId",
                table: "Flights",
                newName: "AirlineId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_AirplaneId",
                table: "Flights",
                newName: "IX_Flights_AirlineId");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Passengers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airlines_AirlineId",
                table: "Flights",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "AirlineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airlines_AirlineId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "AirlineId",
                table: "Flights",
                newName: "AirplaneId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_AirlineId",
                table: "Flights",
                newName: "IX_Flights_AirplaneId");

            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    AirplaneId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AirlineId = table.Column<int>(type: "integer", nullable: false),
                    AirplaneName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.AirplaneId);
                    table.ForeignKey(
                        name: "FK_Airplanes_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "AirlineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airplanes_AirlineId",
                table: "Airplanes",
                column: "AirlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airplanes_AirplaneId",
                table: "Flights",
                column: "AirplaneId",
                principalTable: "Airplanes",
                principalColumn: "AirplaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
