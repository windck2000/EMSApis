using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSApi.Migrations
{
    public partial class uppermissioncs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissioncsTwo",
                table: "SYS_PERMISSIONCS");

            migrationBuilder.AddColumn<string>(
                name: "FunctionsRemarks",
                table: "SYS_PERMISSIONCS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FunctionsRemarks",
                table: "SYS_PERMISSIONCS");

            migrationBuilder.AddColumn<int>(
                name: "PermissioncsTwo",
                table: "SYS_PERMISSIONCS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
