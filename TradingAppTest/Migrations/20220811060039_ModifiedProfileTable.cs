using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingAppTest.Migrations
{
    public partial class ModifiedProfileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                table: "profiles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "users",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
