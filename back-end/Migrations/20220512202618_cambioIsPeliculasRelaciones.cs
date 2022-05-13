using Microsoft.EntityFrameworkCore.Migrations;

namespace back_end.Migrations
{
    public partial class cambioIsPeliculasRelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasActores_Peliculas_PeliculasId",
                table: "PeliculasActores");

            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasCines_Peliculas_PeliculasId",
                table: "PeliculasCines");

            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasGeneros_Peliculas_PeliculasId",
                table: "PeliculasGeneros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeliculasGeneros",
                table: "PeliculasGeneros");

            migrationBuilder.DropIndex(
                name: "IX_PeliculasGeneros_PeliculasId",
                table: "PeliculasGeneros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeliculasCines",
                table: "PeliculasCines");

            migrationBuilder.DropIndex(
                name: "IX_PeliculasCines_PeliculasId",
                table: "PeliculasCines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeliculasActores",
                table: "PeliculasActores");

            migrationBuilder.DropColumn(
                name: "PeliculaId",
                table: "PeliculasGeneros");

            migrationBuilder.DropColumn(
                name: "PeliculaId",
                table: "PeliculasCines");

            migrationBuilder.DropColumn(
                name: "PeliculaId",
                table: "PeliculasActores");

            migrationBuilder.AlterColumn<int>(
                name: "PeliculasId",
                table: "PeliculasGeneros",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PeliculasId",
                table: "PeliculasCines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PeliculasId",
                table: "PeliculasActores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeliculasGeneros",
                table: "PeliculasGeneros",
                columns: new[] { "PeliculasId", "GeneroId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeliculasCines",
                table: "PeliculasCines",
                columns: new[] { "PeliculasId", "CineId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeliculasActores",
                table: "PeliculasActores",
                columns: new[] { "ActorId", "PeliculasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasActores_Peliculas_PeliculasId",
                table: "PeliculasActores",
                column: "PeliculasId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasCines_Peliculas_PeliculasId",
                table: "PeliculasCines",
                column: "PeliculasId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasGeneros_Peliculas_PeliculasId",
                table: "PeliculasGeneros",
                column: "PeliculasId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasActores_Peliculas_PeliculasId",
                table: "PeliculasActores");

            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasCines_Peliculas_PeliculasId",
                table: "PeliculasCines");

            migrationBuilder.DropForeignKey(
                name: "FK_PeliculasGeneros_Peliculas_PeliculasId",
                table: "PeliculasGeneros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeliculasGeneros",
                table: "PeliculasGeneros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeliculasCines",
                table: "PeliculasCines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeliculasActores",
                table: "PeliculasActores");

            migrationBuilder.AlterColumn<int>(
                name: "PeliculasId",
                table: "PeliculasGeneros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PeliculaId",
                table: "PeliculasGeneros",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PeliculasId",
                table: "PeliculasCines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PeliculaId",
                table: "PeliculasCines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PeliculasId",
                table: "PeliculasActores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PeliculaId",
                table: "PeliculasActores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeliculasGeneros",
                table: "PeliculasGeneros",
                columns: new[] { "PeliculaId", "GeneroId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeliculasCines",
                table: "PeliculasCines",
                columns: new[] { "PeliculaId", "CineId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeliculasActores",
                table: "PeliculasActores",
                columns: new[] { "ActorId", "PeliculaId" });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasGeneros_PeliculasId",
                table: "PeliculasGeneros",
                column: "PeliculasId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculasCines_PeliculasId",
                table: "PeliculasCines",
                column: "PeliculasId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasActores_Peliculas_PeliculasId",
                table: "PeliculasActores",
                column: "PeliculasId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasCines_Peliculas_PeliculasId",
                table: "PeliculasCines",
                column: "PeliculasId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PeliculasGeneros_Peliculas_PeliculasId",
                table: "PeliculasGeneros",
                column: "PeliculasId",
                principalTable: "Peliculas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
