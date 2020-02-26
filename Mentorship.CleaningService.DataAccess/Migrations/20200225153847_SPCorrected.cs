using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentorship.CleaningService.DataAccess.Migrations
{
    public partial class SPCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DemandStatusId",
                table: "ClientsDemands");

            migrationBuilder.AddColumn<string>(
                name: "DemandStatusName",
                table: "ClientsDemands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DemandStatusName",
                table: "ClientsDemands");

            migrationBuilder.AddColumn<int>(
                name: "DemandStatusId",
                table: "ClientsDemands",
                nullable: false,
                defaultValue: 0);
        }
    }
}
