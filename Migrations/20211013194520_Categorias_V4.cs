using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class Categorias_V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaGame");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_CategoriaId",
                table: "Game",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasGames_JogosId",
                table: "CategoriasGames",
                column: "JogosId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriasGames_Categorias_CategoriasId",
                table: "CategoriasGames",
                column: "CategoriasId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriasGames_Game_JogosId",
                table: "CategoriasGames",
                column: "JogosId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Categorias_CategoriaId",
                table: "Game",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriasGames_Categorias_CategoriasId",
                table: "CategoriasGames");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriasGames_Game_JogosId",
                table: "CategoriasGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Categorias_CategoriaId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_CategoriaId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_CategoriasGames_JogosId",
                table: "CategoriasGames");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Game");

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

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaGame_JogosId",
                table: "CategoriaGame",
                column: "JogosId");
        }
    }
}
