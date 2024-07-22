using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titlu = table.Column<string>(type: "TEXT", nullable: false),
                    Isbn = table.Column<string>(type: "TEXT", nullable: false),
                    NrPagini = table.Column<int>(type: "INTEGER", nullable: false),
                    DataAparitie = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Link = table.Column<string>(type: "TEXT", nullable: true),
                    Descriere = table.Column<string>(type: "TEXT", nullable: false),
                    Poza = table.Column<string>(type: "TEXT", nullable: false),
                    Pret = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genuri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nume = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genuri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tropeuri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nume = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tropeuri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Parola = table.Column<string>(type: "TEXT", nullable: false),
                    Nume = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarteGen",
                columns: table => new
                {
                    CartiId = table.Column<int>(type: "INTEGER", nullable: false),
                    GenuriId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteGen", x => new { x.CartiId, x.GenuriId });
                    table.ForeignKey(
                        name: "FK_CarteGen_Carti_CartiId",
                        column: x => x.CartiId,
                        principalTable: "Carti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarteGen_Genuri_GenuriId",
                        column: x => x.GenuriId,
                        principalTable: "Genuri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarteTrope",
                columns: table => new
                {
                    CartiId = table.Column<int>(type: "INTEGER", nullable: false),
                    TropeuriId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteTrope", x => new { x.CartiId, x.TropeuriId });
                    table.ForeignKey(
                        name: "FK_CarteTrope_Carti_CartiId",
                        column: x => x.CartiId,
                        principalTable: "Carti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarteTrope_Tropeuri_TropeuriId",
                        column: x => x.TropeuriId,
                        principalTable: "Tropeuri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recenzii",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Rating = table.Column<float>(type: "REAL", nullable: false),
                    CarteId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recenzii_Carti_CarteId",
                        column: x => x.CarteId,
                        principalTable: "Carti",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recenzii_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarteGen_GenuriId",
                table: "CarteGen",
                column: "GenuriId");

            migrationBuilder.CreateIndex(
                name: "IX_CarteTrope_TropeuriId",
                table: "CarteTrope",
                column: "TropeuriId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzii_CarteId",
                table: "Recenzii",
                column: "CarteId");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzii_UserId",
                table: "Recenzii",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarteGen");

            migrationBuilder.DropTable(
                name: "CarteTrope");

            migrationBuilder.DropTable(
                name: "Recenzii");

            migrationBuilder.DropTable(
                name: "Genuri");

            migrationBuilder.DropTable(
                name: "Tropeuri");

            migrationBuilder.DropTable(
                name: "Carti");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
