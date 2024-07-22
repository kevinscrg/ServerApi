using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genuri",
                columns: new[] { "Id", "Nume" },
                values: new object[,]
                {
                    { 1, "Thriller" },
                    { 2, "Romance" },
                    { 3, "Drama" },
                    { 4, "Politist" }
                });

            migrationBuilder.InsertData(
                table: "Tropeuri",
                columns: new[] { "Id", "Nume" },
                values: new object[,]
                {
                    { 1, "enemies to lovers" },
                    { 2, "so many lies" },
                    { 3, "twist ending" },
                    { 4, "undercover mission" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genuri",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genuri",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genuri",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genuri",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tropeuri",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tropeuri",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tropeuri",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tropeuri",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
