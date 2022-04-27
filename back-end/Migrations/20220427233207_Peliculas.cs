using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end.Migrations
{
    public partial class Peliculas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Resumen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Trailer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnCines = table.Column<bool>(type: "bit", nullable: false),
                    FechaLanzamineto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeliculasActores",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    PeliculasId = table.Column<int>(type: "int", nullable: true),
                    ActoresId = table.Column<int>(type: "int", nullable: true),
                    Personaje = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasActores", x => new { x.ActorId, x.PeliculaId });
                    table.ForeignKey(
                        name: "FK_PeliculasActores_Actores_ActoresId",
                        column: x => x.ActoresId,
                        principalTable: "Actores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeliculasActores_Peliculas_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeliculasCines",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    CineId = table.Column<int>(type: "int", nullable: false),
                    PeliculasId = table.Column<int>(type: "int", nullable: true),
                    CinesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasCines", x => new { x.CineId, x.PeliculaId });
                    table.ForeignKey(
                        name: "FK_PeliculasCines_Cines_CinesId",
                        column: x => x.CinesId,
                        principalTable: "Cines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeliculasCines_Peliculas_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeliculasGeneros",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    PeliculasId = table.Column<int>(type: "int", nullable: true),
                    GenerosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculasGeneros", x => new { x.GeneroId, x.PeliculaId });
                    table.ForeignKey(
                        name: "FK_PeliculasGeneros_Generos_GenerosId",
                        column: x => x.GenerosId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeliculasGeneros_Peliculas_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Peliculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasActores_ActoresId",
                table: "PeliculasActores",
                column: "ActoresId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasActores_PeliculasId",
                table: "PeliculasActores",
                column: "PeliculasId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasCines_CinesId",
                table: "PeliculasCines",
                column: "CinesId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasCines_PeliculasId",
                table: "PeliculasCines",
                column: "PeliculasId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasGeneros_GenerosId",
                table: "PeliculasGeneros",
                column: "GenerosId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasGeneros_PeliculasId",
                table: "PeliculasGeneros",
                column: "PeliculasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculasActores");

            migrationBuilder.DropTable(
                name: "PeliculasCines");

            migrationBuilder.DropTable(
                name: "PeliculasGeneros");

            migrationBuilder.DropTable(
                name: "Peliculas");
        }
    }
}
