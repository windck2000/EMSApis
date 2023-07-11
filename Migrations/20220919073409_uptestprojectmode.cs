using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSApi.Migrations
{
    public partial class uptestprojectmode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectSource",
                table: "SYS_TESTPROJECTMODE",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TestDemand",
                table: "SYS_TESTPROJECTMODE",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectSource",
                table: "SYS_TESTPROJECTMODE");

            migrationBuilder.DropColumn(
                name: "TestDemand",
                table: "SYS_TESTPROJECTMODE");
        }
    }
}
