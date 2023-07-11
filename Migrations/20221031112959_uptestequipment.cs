using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSApi.Migrations
{
    public partial class uptestequipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentIp",
                table: "SYS_TESTEQUIPMENT");

            migrationBuilder.DropColumn(
                name: "EquipmentType",
                table: "SYS_TESTEQUIPMENT");
        }
    }
}
