using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingAppTest.Migrations
{
    public partial class anothermigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_profiles_ProfileRefId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "ProfileRefId",
                table: "users",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_users_ProfileRefId",
                table: "users",
                newName: "IX_users_userId");

            migrationBuilder.RenameColumn(
                name: "profile_id",
                table: "profiles",
                newName: "profileId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_profiles_userId",
                table: "users",
                column: "userId",
                principalTable: "profiles",
                principalColumn: "profileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_profiles_userId",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "users",
                newName: "ProfileRefId");

            migrationBuilder.RenameIndex(
                name: "IX_users_userId",
                table: "users",
                newName: "IX_users_ProfileRefId");

            migrationBuilder.RenameColumn(
                name: "profileId",
                table: "profiles",
                newName: "profile_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_profiles_ProfileRefId",
                table: "users",
                column: "ProfileRefId",
                principalTable: "profiles",
                principalColumn: "profile_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
