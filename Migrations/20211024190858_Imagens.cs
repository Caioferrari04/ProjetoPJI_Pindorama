using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class Imagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Categorias_CategoriaId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "CategoriasGames");

            migrationBuilder.DropIndex(
                name: "IX_Game_CategoriaId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "LinkImages",
                table: "Game");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataLancamento",
                table: "Game",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CategoriaGame",
                columns: table => new
                {
                    CategoriasId = table.Column<int>(type: "int", nullable: false),
                    JogosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaGame", x => new { x.CategoriasId, x.JogosId });
                    table.ForeignKey(
                        name: "FK_CategoriaGame_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaGame_Game_JogosId",
                        column: x => x.JogosId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkImagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagens_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaGame_JogosId",
                table: "CategoriaGame",
                column: "JogosId");

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_GameId",
                table: "Imagens",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaGame");

            migrationBuilder.DropTable(
                name: "Imagens");

            migrationBuilder.DropColumn(
                name: "DataLancamento",
                table: "Game");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkImages",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriasGames",
                columns: table => new
                {
                    CategoriasId = table.Column<int>(type: "int", nullable: false),
                    JogosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasGames", x => new { x.CategoriasId, x.JogosId });
                    table.ForeignKey(
                        name: "FK_CategoriasGames_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriasGames_Game_JogosId",
                        column: x => x.JogosId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_CategoriaId",
                table: "Game",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasGames_JogosId",
                table: "CategoriasGames",
                column: "JogosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Categorias_CategoriaId",
                table: "Game",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
