using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class HerancaLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.CreateTable(
                name: "LikeComments",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeComments", x => new { x.UsuarioId, x.CommentId });
                    table.ForeignKey(
                        name: "FK_LikeComments_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeComments_Comentarios_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comentarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LikePosts",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikePosts", x => new { x.UsuarioId, x.PostId });
                    table.ForeignKey(
                        name: "FK_LikePosts_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikePosts_Postagens_PostId",
                        column: x => x.PostId,
                        principalTable: "Postagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikeComments_CommentId",
                table: "LikeComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_LikePosts_PostId",
                table: "LikePosts",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikeComments");

            migrationBuilder.DropTable(
                name: "LikePosts");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComentarioId = table.Column<int>(type: "int", nullable: true),
                    PostagemId = table.Column<int>(type: "int", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Comentarios_ComentarioId",
                        column: x => x.ComentarioId,
                        principalTable: "Comentarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Postagens_PostagemId",
                        column: x => x.PostagemId,
                        principalTable: "Postagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_ComentarioId",
                table: "Likes",
                column: "ComentarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostagemId",
                table: "Likes",
                column: "PostagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UsuarioId",
                table: "Likes",
                column: "UsuarioId");
        }
    }
}
