using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSApi.Migrations
{
    public partial class addAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AgeDate",
                table: "SYS_ACCOUNT",
                newName: "CreationDate");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "SYS_ACCOUNT",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "SYS_ACCOUNT",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "SYS_ACCOUNT");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "SYS_ACCOUNT");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "SYS_ACCOUNT",
                newName: "AgeDate");
        }
    }
}
