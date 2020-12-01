using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boek.Data.Migrations
{
    public partial class versie1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FotoId",
                table: "Boeken",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FotoId",
                table: "Auteurs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DbImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<byte[]>(type: "BLOB", nullable: false),
                    ImageType = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbImages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boeken_FotoId",
                table: "Boeken",
                column: "FotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Auteurs_FotoId",
                table: "Auteurs",
                column: "FotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Auteurs_DbImages_FotoId",
                table: "Auteurs",
                column: "FotoId",
                principalTable: "DbImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Boeken_DbImages_FotoId",
                table: "Boeken",
                column: "FotoId",
                principalTable: "DbImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auteurs_DbImages_FotoId",
                table: "Auteurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Boeken_DbImages_FotoId",
                table: "Boeken");

            migrationBuilder.DropTable(
                name: "DbImages");

            migrationBuilder.DropIndex(
                name: "IX_Boeken_FotoId",
                table: "Boeken");

            migrationBuilder.DropIndex(
                name: "IX_Auteurs_FotoId",
                table: "Auteurs");

            migrationBuilder.DropColumn(
                name: "FotoId",
                table: "Boeken");

            migrationBuilder.DropColumn(
                name: "FotoId",
                table: "Auteurs");
        }
    }
}
