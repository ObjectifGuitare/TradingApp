using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingAppTest.Migrations
{
    public partial class CorrectedOneToOneForUserAndProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_profiles_userId",
                table: "profiles");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "profiles");

            migrationBuilder.CreateIndex(
                name: "IX_profiles_userId",
                table: "profiles",
                column: "userId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_profiles_userId",
                table: "profiles");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_profiles_userId",
                table: "profiles",
                column: "userId");
        }
    }
}
