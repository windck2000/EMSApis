﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSApi.Migrations
{
    public partial class addtestequioment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EquipmentNo",
                table: "SYS_TESTEQUIPMENT",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EquipmentNo",
                table: "SYS_TESTEQUIPMENT",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
