using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace samuraiApp.Data.Migrations
{
    public partial class MtoMpayload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Battle_BattlesBattleId",
                table: "BattleSamurai");

            migrationBuilder.RenameColumn(
                name: "BattlesBattleId",
                table: "BattleSamurai",
                newName: "BattleId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateJoined",
                table: "BattleSamurai",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Battle_BattleId",
                table: "BattleSamurai",
                column: "BattleId",
                principalTable: "Battle",
                principalColumn: "BattleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Battle_BattleId",
                table: "BattleSamurai");

            migrationBuilder.RenameColumn(
                name: "BattleId",
                table: "BattleSamurai",
                newName: "BattlesBattleId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateJoined",
                table: "BattleSamurai",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Battle_BattlesBattleId",
                table: "BattleSamurai",
                column: "BattlesBattleId",
                principalTable: "Battle",
                principalColumn: "BattleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
