using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingAppTest.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_profiles_userId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_userId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "users");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_userId",
                table: "profiles",
                column: "userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_profiles_users_userId",
                table: "profiles",
                column: "userId",
                principalTable: "users",
                principalColumn: "user_id",
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

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_userId",
                table: "users",
                column: "userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_profiles_userId",
                table: "users",
                column: "userId",
                principalTable: "profiles",
                principalColumn: "profileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
