using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingAppTest.Migrations
{
    public partial class anothermigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profiles_users_userId",
                table: "profiles");

            migrationBuilder.DropIndex(
                name: "IX_profiles_userId",
                table: "profiles");

            migrationBuilder.AddColumn<int>(
                name: "ProfileRefId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_ProfileRefId",
                table: "users",
                column: "ProfileRefId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_users_profiles_ProfileRefId",
                table: "users",
                column: "ProfileRefId",
                principalTable: "profiles",
                principalColumn: "profile_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_profiles_ProfileRefId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_ProfileRefId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ProfileRefId",
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
    }
}
