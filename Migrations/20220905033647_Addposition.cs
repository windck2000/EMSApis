using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSApi.Migrations
{
    public partial class Addposition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "PositionNumber");

            migrationBuilder.CreateTable(
                name: "SYS_POSITION",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR AccountApplicationNumber"),
                    DepartmentName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PositionUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SYS_POSITION", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SYS_POSITION_PositionName_Id",
                table: "SYS_POSITION",
                columns: new[] { "PositionName", "Id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SYS_POSITION");

            migrationBuilder.DropSequence(
                name: "PositionNumber");
        }
    }
}
