using Microsoft.EntityFrameworkCore.Migrations;

namespace Boek.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtiestenNaam = table.Column<string>(nullable: false),
                    Voornaam = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true),
                    Woonplaats = table.Column<string>(nullable: true),
                    Achtergrond = table.Column<string>(nullable: true),
                    Afbeelding = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoekVorm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Omschrijving = table.Column<string>(nullable: true),
                    Digitaal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoekVorm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Omschrijving = table.Column<string>(nullable: true),
                    Doelgroep = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Talen",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 5, nullable: false),
                    Naam = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talen", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Uitgeverijen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(nullable: false),
                    Hoofdkwartier = table.Column<string>(nullable: true),
                    Oprichter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uitgeverijen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GenreId = table.Column<int>(nullable: false),
                    Omschrijving = table.Column<string>(nullable: true),
                    Doelgroep = table.Column<int>(nullable: true),
                    MinLeeftijd = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boeken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(nullable: false),
                    GenreId = table.Column<int>(nullable: true),
                    VormId = table.Column<int>(nullable: true),
                    TaalKey = table.Column<string>(nullable: true),
                    AuteurId = table.Column<int>(nullable: true),
                    UitgeverijId = table.Column<int>(nullable: true),
                    KorteInhoud = table.Column<string>(nullable: true),
                    ISBN10 = table.Column<string>(maxLength: 10, nullable: true),
                    ISBN13 = table.Column<string>(maxLength: 15, nullable: true),
                    EAN = table.Column<string>(maxLength: 18, nullable: true),
                    Afbeelding = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boeken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boeken_Auteurs_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Auteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boeken_SubGenres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "SubGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boeken_Talen_TaalKey",
                        column: x => x.TaalKey,
                        principalTable: "Talen",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boeken_Uitgeverijen_UitgeverijId",
                        column: x => x.UitgeverijId,
                        principalTable: "Uitgeverijen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boeken_BoekVorm_VormId",
                        column: x => x.VormId,
                        principalTable: "BoekVorm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boeken_AuteurId",
                table: "Boeken",
                column: "AuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Boeken_GenreId",
                table: "Boeken",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Boeken_TaalKey",
                table: "Boeken",
                column: "TaalKey");

            migrationBuilder.CreateIndex(
                name: "IX_Boeken_UitgeverijId",
                table: "Boeken",
                column: "UitgeverijId");

            migrationBuilder.CreateIndex(
                name: "IX_Boeken_VormId",
                table: "Boeken",
                column: "VormId");

            migrationBuilder.CreateIndex(
                name: "IX_SubGenres_GenreId",
                table: "SubGenres",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boeken");

            migrationBuilder.DropTable(
                name: "Auteurs");

            migrationBuilder.DropTable(
                name: "SubGenres");

            migrationBuilder.DropTable(
                name: "Talen");

            migrationBuilder.DropTable(
                name: "Uitgeverijen");

            migrationBuilder.DropTable(
                name: "BoekVorm");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
