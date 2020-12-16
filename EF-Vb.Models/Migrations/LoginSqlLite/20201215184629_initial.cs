using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Vb.Models.Migrations.LoginSqlLite
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groepen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Opmerkingen = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groepen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoginNaam = table.Column<string>(type: "TEXT", nullable: false),
                    Paswoord = table.Column<string>(type: "TEXT", nullable: false),
                    Opmerkingen = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroepLogin",
                columns: table => new
                {
                    LedenId = table.Column<int>(type: "INTEGER", nullable: false),
                    LidVanId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroepLogin", x => new { x.LedenId, x.LidVanId });
                    table.ForeignKey(
                        name: "FK_GroepLogin_Groepen_LidVanId",
                        column: x => x.LidVanId,
                        principalTable: "Groepen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroepLogin_Logins_LedenId",
                        column: x => x.LedenId,
                        principalTable: "Logins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groepen",
                columns: new[] { "Id", "Naam", "Opmerkingen" },
                values: new object[] { 1, "Default", "" });

            migrationBuilder.CreateIndex(
                name: "IX_GroepLogin_LidVanId",
                table: "GroepLogin",
                column: "LidVanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroepLogin");

            migrationBuilder.DropTable(
                name: "Groepen");

            migrationBuilder.DropTable(
                name: "Logins");
        }
    }
}
