using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.API.Migrations
{
    public partial class initdb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "tblparsel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userid",
                table: "tblparsel");
        }
    }
}
