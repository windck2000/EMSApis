using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSApi.Migrations
{
    public partial class upmodelconfi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SYS_MODELCONFIGURATION",
                table: "SYS_MODELCONFIGURATION");

            migrationBuilder.DropColumn(
                name: "ConfigurationName",
                table: "SYS_MODELCONFIGURATION");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "SYS_MODELCONFIGURATION",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SYS_MODELCONFIGURATION",
                table: "SYS_MODELCONFIGURATION",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SYS_MODELCONFIGURATION",
                table: "SYS_MODELCONFIGURATION");

            migrationBuilder.DropColumn(
                name: "id",
                table: "SYS_MODELCONFIGURATION");

            migrationBuilder.AddColumn<string>(
                name: "ConfigurationName",
                table: "SYS_MODELCONFIGURATION",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SYS_MODELCONFIGURATION",
                table: "SYS_MODELCONFIGURATION",
                column: "ConfigurationName");
        }
    }
}
