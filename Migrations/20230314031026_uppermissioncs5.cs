using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSApi.Migrations
{
    public partial class uppermissioncs5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlIco",
                table: "SYS_PERMISSIONCS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MqIco",
                table: "SYS_PERMISSIONCS",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlIco",
                table: "SYS_PERMISSIONCS");

            migrationBuilder.DropColumn(
                name: "MqIco",
                table: "SYS_PERMISSIONCS");
        }
    }
}
