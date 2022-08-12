using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingAppTest.Migrations
{
    public partial class AddedForeignKeyInProfileViaUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_profiles_userId",
                table: "profiles",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_profiles_users_userId",
                table: "profiles",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profiles_users_userId",
                table: "profiles");

            migrationBuilder.DropIndex(
                name: "IX_profiles_userId",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "profiles");
        }
    }
}
