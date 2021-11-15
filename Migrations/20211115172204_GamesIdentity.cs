using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class GamesIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_AspNetUsers_UsuarioId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "GameUserAntigo");

            migrationBuilder.DropIndex(
                name: "IX_Game_UsuarioId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Game");

            migrationBuilder.AddColumn<int>(
                name: "UserAntigoId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameUsuario",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUsuario", x => new { x.GamesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GameUsuario_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUsuario_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_UserAntigoId",
                table: "Game",
                column: "UserAntigoId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUsuario_UsersId",
                table: "GameUsuario",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_UserAntigo_UserAntigoId",
                table: "Game",
                column: "UserAntigoId",
                principalTable: "UserAntigo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_UserAntigo_UserAntigoId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "GameUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Game_UserAntigoId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "UserAntigoId",
                table: "Game");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Game",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameUserAntigo",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUserAntigo", x => new { x.GamesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GameUserAntigo_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUserAntigo_UserAntigo_UsersId",
                        column: x => x.UsersId,
                        principalTable: "UserAntigo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_UsuarioId",
                table: "Game",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUserAntigo_UsersId",
                table: "GameUserAntigo",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_AspNetUsers_UsuarioId",
                table: "Game",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
