using Microsoft.EntityFrameworkCore.Migrations;

namespace OnePunch.Migrations
{
    public partial class ChangedPunchtoPunches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Punch",
                table: "Punch");

            migrationBuilder.RenameTable(
                name: "Punch",
                newName: "Punches");

            migrationBuilder.RenameIndex(
                name: "IX_Punch_ClockIn_IsClockedIn",
                table: "Punches",
                newName: "IX_Punches_ClockIn_IsClockedIn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Punches",
                table: "Punches",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Punches",
                table: "Punches");

            migrationBuilder.RenameTable(
                name: "Punches",
                newName: "Punch");

            migrationBuilder.RenameIndex(
                name: "IX_Punches_ClockIn_IsClockedIn",
                table: "Punch",
                newName: "IX_Punch_ClockIn_IsClockedIn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Punch",
                table: "Punch",
                column: "Id");
        }
    }
}
