using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class HerancaLike2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeComments_Comentarios_CommentId",
                table: "LikeComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts");

            migrationBuilder.DropIndex(
                name: "IX_LikePosts_PostId",
                table: "LikePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments");

            migrationBuilder.DropIndex(
                name: "IX_LikeComments_CommentId",
                table: "LikeComments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts",
                columns: new[] { "PostId", "UsuarioId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments",
                columns: new[] { "CommentId", "UsuarioId" });

            migrationBuilder.CreateIndex(
                name: "IX_LikePosts_UsuarioId",
                table: "LikePosts",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeComments_UsuarioId",
                table: "LikeComments",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComments_Comentarios_CommentId",
                table: "LikeComments",
                column: "CommentId",
                principalTable: "Comentarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeComments_Comentarios_CommentId",
                table: "LikeComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts");

            migrationBuilder.DropIndex(
                name: "IX_LikePosts_UsuarioId",
                table: "LikePosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments");

            migrationBuilder.DropIndex(
                name: "IX_LikeComments_UsuarioId",
                table: "LikeComments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikePosts",
                table: "LikePosts",
                columns: new[] { "UsuarioId", "PostId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeComments",
                table: "LikeComments",
                columns: new[] { "UsuarioId", "CommentId" });

            migrationBuilder.CreateIndex(
                name: "IX_LikePosts_PostId",
                table: "LikePosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeComments_CommentId",
                table: "LikeComments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeComments_Comentarios_CommentId",
                table: "LikeComments",
                column: "CommentId",
                principalTable: "Comentarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
