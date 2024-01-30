using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TvShows.Migrations
{
    /// <inheritdoc />
    public partial class bla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "year",
                table: "TvShows",
                newName: "Year");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "TvShows",
                newName: "year");
        }
    }
}
