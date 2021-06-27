using Microsoft.EntityFrameworkCore.Migrations;

namespace OnePunch.Migrations
{
    public partial class AlteredRoleIDToRoleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Punch_ClockIn",
                table: "Punch");

            migrationBuilder.DropColumn(
                name: "AspNetUserRoleId",
                table: "Punch");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "Punch",
                type: "longtext",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUserRoleName",
                table: "Punch",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Punch_ClockIn_IsClockedIn",
                table: "Punch",
                columns: new[] { "ClockIn", "IsClockedIn" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Punch_ClockIn_IsClockedIn",
                table: "Punch");

            migrationBuilder.DropColumn(
                name: "AspNetUserRoleName",
                table: "Punch");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUserId",
                table: "Punch",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AspNetUserRoleId",
                table: "Punch",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Punch_ClockIn",
                table: "Punch",
                column: "ClockIn");
        }
    }
}
