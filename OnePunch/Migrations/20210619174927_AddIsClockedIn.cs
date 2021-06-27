using Microsoft.EntityFrameworkCore.Migrations;

namespace OnePunch.Migrations
{
    public partial class AddIsClockedIn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsClockedIn",
                table: "Punch",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClockedIn",
                table: "Punch");
        }
    }
}
