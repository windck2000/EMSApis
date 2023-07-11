using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSApi.Migrations
{
    public partial class addtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SYS_POSITION",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR PositionNumber",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR AccountApplicationNumber");

            migrationBuilder.CreateTable(
                name: "SYS_MODEL",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_MODEL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_MODELCONFIGURATION",
                columns: table => new
                {
                    ConfigurationName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TestItem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_MODELCONFIGURATION", x => x.ConfigurationName);
                });

            migrationBuilder.CreateTable(
                name: "SYS_TESTERMACHINE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MacgineName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MacgineCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MacgineVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MacgineState = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_TESTERMACHINE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SYS_TESTITEM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TestDescription = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_TESTITEM", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SYS_MODEL_ModelName",
                table: "SYS_MODEL",
                column: "ModelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SYS_TESTERMACHINE_MacgineName",
                table: "SYS_TESTERMACHINE",
                column: "MacgineName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SYS_TESTITEM_TestName",
                table: "SYS_TESTITEM",
                column: "TestName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SYS_MODEL");

            migrationBuilder.DropTable(
                name: "SYS_MODELCONFIGURATION");

            migrationBuilder.DropTable(
                name: "SYS_TESTERMACHINE");

            migrationBuilder.DropTable(
                name: "SYS_TESTITEM");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SYS_POSITION",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR AccountApplicationNumber",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR PositionNumber");
        }
    }
}
