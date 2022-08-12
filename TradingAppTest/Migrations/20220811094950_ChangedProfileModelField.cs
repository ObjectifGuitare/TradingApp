using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingAppTest.Migrations
{
    public partial class ChangedProfileModelField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_id",
                table: "profiles");
        }
    }
}
