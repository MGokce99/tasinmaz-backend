using Microsoft.EntityFrameworkCore.Migrations;

namespace Tasinmaz.API.Migrations
{
    public partial class initdb4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tblparsel_userid",
                table: "tblparsel",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_tblparsel_tblusers_userid",
                table: "tblparsel",
                column: "userid",
                principalTable: "tblusers",
                principalColumn: "userid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblparsel_tblusers_userid",
                table: "tblparsel");

            migrationBuilder.DropIndex(
                name: "IX_tblparsel_userid",
                table: "tblparsel");
        }
    }
}
