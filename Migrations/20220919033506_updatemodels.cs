using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSApi.Migrations
{
    public partial class updatemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SYS_TESTEQUIPMENT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EquipmentName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EquipmentNo = table.Column<int>(type: "int", nullable: false),
                    EquipmentState = table.Column<int>(type: "int", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_TESTEQUIPMENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_TESTPROJECT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectNo = table.Column<int>(type: "int", nullable: false),
                    ProjectSource = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TestDemand = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TestState = table.Column<int>(type: "int", nullable: false),
                    UpdateUser = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_TESTPROJECT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_TESTPROJECTMODE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectNo = table.Column<int>(type: "int", nullable: false),
                    TestMode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TestItem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TestSite = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TestEquipment = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TestUser = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TestPotlife = table.Column<int>(type: "int", nullable: false),
                    TestQty = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_TESTPROJECTMODE", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SYS_TESTEQUIPMENT");

            migrationBuilder.DropTable(
                name: "SYS_TESTPROJECT");

            migrationBuilder.DropTable(
                name: "SYS_TESTPROJECTMODE");
        }
    }
}
