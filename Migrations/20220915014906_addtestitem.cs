﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSApi.Migrations
{
    public partial class addtestitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "SYS_TESTITEM",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "SYS_TESTITEM");
        }
    }
}
