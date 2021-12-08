using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class Like : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PostagemId = table.Column<int>(type: "int", nullable: false),
                    ComentarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Like_Comentarios_ComentarioId",
                        column: x => x.ComentarioId,
                        principalTable: "Comentarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Like_Postagens_PostagemId",
                        column: x => x.PostagemId,
                        principalTable: "Postagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Like_ComentarioId",
                table: "Like",
                column: "ComentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_PostagemId",
                table: "Like",
                column: "PostagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UsuarioId",
                table: "Like",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Like");
        }
    }
}
