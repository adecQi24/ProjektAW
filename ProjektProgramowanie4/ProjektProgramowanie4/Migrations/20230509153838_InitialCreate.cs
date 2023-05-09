using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektProgramowanie4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Liczba_Kilometrow",
                columns: table => new
                {
                    IdLiczby = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiczbaKmKoncowa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liczba_Kilometrow", x => x.IdLiczby);
                });

            migrationBuilder.CreateTable(
                name: "Osoby_Kierujace",
                columns: table => new
                {
                    IdOsoby = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoby_Kierujace", x => x.IdOsoby);
                });

            migrationBuilder.CreateTable(
                name: "Wpisy",
                columns: table => new
                {
                    IdWpisu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOsoby = table.Column<int>(type: "int", nullable: false),
                    IdLiczby = table.Column<int>(type: "int", nullable: false),
                    opis_trasy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DataWyjazdu = table.Column<DateTime>(type: "date", nullable: false),
                    KolejnyNrWpisu = table.Column<int>(type: "int", nullable: false),
                    LiczbaPrzejechanychKm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wpisy", x => x.IdWpisu);
                    table.ForeignKey(
                        name: "FK_Wpisy_Liczba_Kilometrow",
                        column: x => x.IdLiczby,
                        principalTable: "Liczba_Kilometrow",
                        principalColumn: "IdLiczby");
                    table.ForeignKey(
                        name: "FK_Wpisy_Osoby_Kierujace",
                        column: x => x.IdOsoby,
                        principalTable: "Osoby_Kierujace",
                        principalColumn: "IdOsoby");
                });

            migrationBuilder.CreateTable(
                name: "Ewidencje",
                columns: table => new
                {
                    IdEwidencji = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdWpisu = table.Column<int>(type: "int", nullable: false),
                    IdLiczby = table.Column<int>(type: "int", nullable: false),
                    DataRozpoczecia = table.Column<DateTime>(type: "date", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "date", nullable: false),
                    StanLicznikaPoczatkowy = table.Column<int>(type: "int", nullable: false),
                    StanLicznikaKoncowy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ewidencje", x => x.IdEwidencji);
                    table.ForeignKey(
                        name: "FK_Ewidencje_Liczba_Kilometrow",
                        column: x => x.IdLiczby,
                        principalTable: "Liczba_Kilometrow",
                        principalColumn: "IdLiczby");
                    table.ForeignKey(
                        name: "FK_Ewidencje_Wpisy",
                        column: x => x.IdWpisu,
                        principalTable: "Wpisy",
                        principalColumn: "IdWpisu");
                });

            migrationBuilder.CreateTable(
                name: "Pojazdy",
                columns: table => new
                {
                    NrRejestracyjny = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    IdEwidencji = table.Column<int>(type: "int", nullable: true),
                    MarkaPojazdu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RodzajPojazdu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pojazdy", x => x.NrRejestracyjny);
                    table.ForeignKey(
                        name: "FK_Pojazdy_Ewidencje",
                        column: x => x.IdEwidencji,
                        principalTable: "Ewidencje",
                        principalColumn: "IdEwidencji");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ewidencje_IdLiczby",
                table: "Ewidencje",
                column: "IdLiczby");

            migrationBuilder.CreateIndex(
                name: "IX_Ewidencje_IdWpisu",
                table: "Ewidencje",
                column: "IdWpisu");

            migrationBuilder.CreateIndex(
                name: "IX_Pojazdy_IdEwidencji",
                table: "Pojazdy",
                column: "IdEwidencji");

            migrationBuilder.CreateIndex(
                name: "IX_Wpisy_IdLiczby",
                table: "Wpisy",
                column: "IdLiczby");

            migrationBuilder.CreateIndex(
                name: "IX_Wpisy_IdOsoby",
                table: "Wpisy",
                column: "IdOsoby");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pojazdy");

            migrationBuilder.DropTable(
                name: "Ewidencje");

            migrationBuilder.DropTable(
                name: "Wpisy");

            migrationBuilder.DropTable(
                name: "Liczba_Kilometrow");

            migrationBuilder.DropTable(
                name: "Osoby_Kierujace");
        }
    }
}
