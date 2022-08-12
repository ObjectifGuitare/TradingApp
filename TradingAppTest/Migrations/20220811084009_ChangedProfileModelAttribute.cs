using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingAppTest.Migrations
{
    public partial class ChangedProfileModelAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "profiles",
                newName: "profile_id");

            migrationBuilder.AddColumn<int>(
                name: "profile_id",
                table: "trades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profile_id",
                table: "trades");

            migrationBuilder.RenameColumn(
                name: "profile_id",
                table: "profiles",
                newName: "id");
        }
    }
}
