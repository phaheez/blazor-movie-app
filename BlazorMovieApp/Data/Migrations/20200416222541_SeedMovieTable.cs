using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorMovieApp.Data.Migrations
{
    public partial class SeedMovieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Genre", "ReleaseDate", "RunningTime", "Title" },
                values: new object[] { 10, "Robert Wise", "Musical Drama", new DateTime(2012, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 175, "The Sound Of Music" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Genre", "ReleaseDate", "RunningTime", "Title" },
                values: new object[] { 20, "Howard Hawks", "Adventure", new DateTime(2002, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 155, "Hatari" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Genre", "ReleaseDate", "RunningTime", "Title" },
                values: new object[] { 30, "Robert Zemeckis", "Science Fiction", new DateTime(2019, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 116, "Back to the Future" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 30);
        }
    }
}
