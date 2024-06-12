using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Tasinmaz.API.Migrations
{
    public partial class initdb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbliller",
                columns: table => new
                {
                    il_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    il_adi = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbliller", x => x.il_id);
                });

            migrationBuilder.CreateTable(
                name: "tbllogs",
                columns: table => new
                {
                    logid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    durum = table.Column<bool>(nullable: false),
                    islemtipi = table.Column<string>(nullable: true),
                    aciklama = table.Column<string>(nullable: true),
                    tarih = table.Column<DateTime>(nullable: false),
                    logip = table.Column<string>(nullable: true),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbllogs", x => x.logid);
                });

            migrationBuilder.CreateTable(
                name: "tblilceler",
                columns: table => new
                {
                    ilce_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ilce_adi = table.Column<string>(maxLength: 30, nullable: false),
                    il_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblilceler", x => x.ilce_id);
                    table.ForeignKey(
                        name: "FK_tblilceler_tbliller_il_id",
                        column: x => x.il_id,
                        principalTable: "tbliller",
                        principalColumn: "il_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblmahalleler",
                columns: table => new
                {
                    mahalle_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mahalle_adi = table.Column<string>(maxLength: 30, nullable: false),
                    ilce_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblmahalleler", x => x.mahalle_id);
                    table.ForeignKey(
                        name: "FK_tblmahalleler_tblilceler_ilce_id",
                        column: x => x.ilce_id,
                        principalTable: "tblilceler",
                        principalColumn: "ilce_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblparsel",
                columns: table => new
                {
                    parselid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    il = table.Column<int>(nullable: false),
                    ilce = table.Column<int>(nullable: false),
                    mahalleid = table.Column<int>(nullable: false),
                    ada = table.Column<string>(maxLength: 30, nullable: false),
                    parsel = table.Column<string>(maxLength: 30, nullable: false),
                    nitelik = table.Column<string>(maxLength: 30, nullable: false),
                    adres = table.Column<string>(maxLength: 60, nullable: false),
                    x = table.Column<string>(maxLength: 155, nullable: false),
                    y = table.Column<string>(maxLength: 155, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblparsel", x => x.parselid);
                    table.ForeignKey(
                        name: "FK_tblparsel_tblmahalleler_mahalleid",
                        column: x => x.mahalleid,
                        principalTable: "tblmahalleler",
                        principalColumn: "mahalle_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblilceler_il_id",
                table: "tblilceler",
                column: "il_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblmahalleler_ilce_id",
                table: "tblmahalleler",
                column: "ilce_id");

            migrationBuilder.CreateIndex(
                name: "IX_tblparsel_mahalleid",
                table: "tblparsel",
                column: "mahalleid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbllogs");

            migrationBuilder.DropTable(
                name: "tblparsel");

            migrationBuilder.DropTable(
                name: "tblmahalleler");

            migrationBuilder.DropTable(
                name: "tblilceler");

            migrationBuilder.DropTable(
                name: "tbliller");
        }
    }
}
