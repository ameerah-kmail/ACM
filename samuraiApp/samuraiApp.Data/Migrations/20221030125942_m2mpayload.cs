using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace samuraiApp.Data.Migrations
{
    public partial class m2mpayload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateJoined",
                table: "BattleSamurai",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "BattleSamurai");
        }
    }
}
