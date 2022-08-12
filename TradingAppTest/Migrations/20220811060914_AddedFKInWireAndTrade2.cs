using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingAppTest.Migrations
{
    public partial class AddedFKInWireAndTrade2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "profile_id",
                table: "wires",
                newName: "profileid");

            migrationBuilder.RenameColumn(
                name: "profile_id",
                table: "trades",
                newName: "profileid");

            migrationBuilder.CreateIndex(
                name: "IX_wires_profileid",
                table: "wires",
                column: "profileid");

            migrationBuilder.CreateIndex(
                name: "IX_trades_profileid",
                table: "trades",
                column: "profileid");

            migrationBuilder.AddForeignKey(
                name: "FK_trades_profiles_profileid",
                table: "trades",
                column: "profileid",
                principalTable: "profiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_wires_profiles_profileid",
                table: "wires",
                column: "profileid",
                principalTable: "profiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_trades_profiles_profileid",
                table: "trades");

            migrationBuilder.DropForeignKey(
                name: "FK_wires_profiles_profileid",
                table: "wires");

            migrationBuilder.DropIndex(
                name: "IX_wires_profileid",
                table: "wires");

            migrationBuilder.DropIndex(
                name: "IX_trades_profileid",
                table: "trades");

            migrationBuilder.RenameColumn(
                name: "profileid",
                table: "wires",
                newName: "profile_id");

            migrationBuilder.RenameColumn(
                name: "profileid",
                table: "trades",
                newName: "profile_id");
        }
    }
}
