using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class Categorias_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriasGame");

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
                name: "CategoriasGames",
                columns: table => new
                {
                    CategoriasId = table.Column<int>(type: "int", nullable: false),
                    JogosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasGames", x => new { x.CategoriasId, x.JogosId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaGame_JogosId",
                table: "CategoriaGame",
                column: "JogosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaGame");

            migrationBuilder.DropTable(
                name: "CategoriasGames");

            migrationBuilder.CreateTable(
                name: "CategoriasGame",
                columns: table => new
                {
                    CategoriasId = table.Column<int>(type: "int", nullable: false),
                    JogosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasGame", x => new { x.CategoriasId, x.JogosId });
                    table.ForeignKey(
                        name: "FK_CategoriasGame_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriasGame_Game_JogosId",
                        column: x => x.JogosId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasGame_JogosId",
                table: "CategoriasGame",
                column: "JogosId");
        }
    }
}
