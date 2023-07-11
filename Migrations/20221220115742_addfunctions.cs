using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSApi.Migrations
{
    public partial class addfunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentIp",
                table: "SYS_TESTEQUIPMENT");

            migrationBuilder.DropColumn(
                name: "EquipmentType",
                table: "SYS_TESTEQUIPMENT");

            migrationBuilder.CreateTable(
                name: "SYS_FUNCTIONS",
                columns: table => new
                {
                    FunctionsSublevel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FunctionsName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FunctionsRemarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_FUNCTIONS", x => x.FunctionsSublevel);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SYS_FUNCTIONS");

            migrationBuilder.AddColumn<string>(
                name: "EquipmentIp",
                table: "SYS_TESTEQUIPMENT",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EquipmentType",
                table: "SYS_TESTEQUIPMENT",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
