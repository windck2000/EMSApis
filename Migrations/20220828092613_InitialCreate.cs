using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "AccountNumbers");

            migrationBuilder.CreateSequence<int>(
                name: "PermissioncNumbers");

            migrationBuilder.CreateTable(
                name: "SYS_ACCOUNT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 20, nullable: false, defaultValueSql: "NEXT VALUE FOR AccountNumbers"),
                    Name = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AgeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    permission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_ACCOUNT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_PERMISSIONCS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR PermissioncNumbers"),
                    PermissioncsName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PermissioncsDescription = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PermissioncsTwo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_PERMISSIONCS", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SYS_ACCOUNT_Name_Id",
                table: "SYS_ACCOUNT",
                columns: new[] { "Name", "Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SYS_PERMISSIONCS_Id",
                table: "SYS_PERMISSIONCS",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SYS_ACCOUNT");

            migrationBuilder.DropTable(
                name: "SYS_PERMISSIONCS");

            migrationBuilder.DropSequence(
                name: "AccountNumbers");

            migrationBuilder.DropSequence(
                name: "PermissioncNumbers");
        }
    }
}
