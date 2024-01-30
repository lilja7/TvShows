using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TvShows.Migrations
{
    /// <inheritdoc />
    public partial class UpdateActorTvShow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "year",
                table: "TvShows",
                newName: "Year");

            migrationBuilder.CreateTable(
                name: "ActorTvShows",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "INTEGER", nullable: false),
                    TvShowId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorTvShows", x => new { x.ActorId, x.TvShowId });
                    table.ForeignKey(
                        name: "FK_ActorTvShows_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorTvShows_TvShows_TvShowId",
                        column: x => x.TvShowId,
                        principalTable: "TvShows",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorTvShows_TvShowId",
                table: "ActorTvShows",
                column: "TvShowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorTvShows");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "TvShows",
                newName: "year");
        }
    }
}
