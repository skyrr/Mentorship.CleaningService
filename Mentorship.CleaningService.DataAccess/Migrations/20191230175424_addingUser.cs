using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentorship.CleaningService.DataAccess.Migrations
{
    public partial class addingUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAddress_Addresses_AddressId",
                table: "ClientAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientAddress_Clients_ClientId",
                table: "ClientAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientAddress",
                table: "ClientAddress");

            migrationBuilder.RenameTable(
                name: "ClientAddress",
                newName: "ClientAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_ClientAddress_AddressId",
                table: "ClientAddresses",
                newName: "IX_ClientAddresses_AddressId");

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Workers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientAddresses",
                table: "ClientAddresses",
                columns: new[] { "ClientId", "AddressId" });

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WorkerId",
                table: "Workers",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleId",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAddresses_Addresses_AddressId",
                table: "ClientAddresses",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAddresses_Clients_ClientId",
                table: "ClientAddresses",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Roles_RoleId",
                table: "Roles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Workers_WorkerId",
                table: "Workers",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAddresses_Addresses_AddressId",
                table: "ClientAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientAddresses_Clients_ClientId",
                table: "ClientAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Roles_RoleId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Workers_WorkerId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_WorkerId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleId",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientAddresses",
                table: "ClientAddresses");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "ClientAddresses",
                newName: "ClientAddress");

            migrationBuilder.RenameIndex(
                name: "IX_ClientAddresses_AddressId",
                table: "ClientAddress",
                newName: "IX_ClientAddress_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientAddress",
                table: "ClientAddress",
                columns: new[] { "ClientId", "AddressId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAddress_Addresses_AddressId",
                table: "ClientAddress",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAddress_Clients_ClientId",
                table: "ClientAddress",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
