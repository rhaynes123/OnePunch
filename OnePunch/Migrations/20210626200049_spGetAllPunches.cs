using Microsoft.EntityFrameworkCore.Migrations;
using MySqlConnector;

namespace OnePunch.Migrations
{
    public partial class spGetAllPunches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            string sql = @"CREATE PROCEDURE GetAllPunches ()
                        BEGIN

                            SELECT * FROM OnePunch.Punches;

                        END";

            migrationBuilder.Sql(sql);
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" DROP procedure IF EXISTS GetAllPunches;");
        }
    }
}
