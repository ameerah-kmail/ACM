using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace samuraiApp.Data.Migrations
{
    public partial class ManytoManyPayload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Samurais_SamuraisId",
                table: "BattleSamurai");

            migrationBuilder.RenameColumn(
                name: "SamuraisId",
                table: "BattleSamurai",
                newName: "SamuraiId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleSamurai_SamuraisId",
                table: "BattleSamurai",
                newName: "IX_BattleSamurai_SamuraiId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Samurais_SamuraiId",
                table: "BattleSamurai",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Samurais_SamuraiId",
                table: "BattleSamurai");

            migrationBuilder.RenameColumn(
                name: "SamuraiId",
                table: "BattleSamurai",
                newName: "SamuraisId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleSamurai_SamuraiId",
                table: "BattleSamurai",
                newName: "IX_BattleSamurai_SamuraisId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Samurais_SamuraisId",
                table: "BattleSamurai",
                column: "SamuraisId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
