using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class LikesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Like_AspNetUsers_UsuarioId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Comentarios_ComentarioId",
                table: "Like");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_Postagens_PostagemId",
                table: "Like");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "Likes");

            migrationBuilder.RenameIndex(
                name: "IX_Like_UsuarioId",
                table: "Likes",
                newName: "IX_Likes_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_PostagemId",
                table: "Likes",
                newName: "IX_Likes_PostagemId");

            migrationBuilder.RenameIndex(
                name: "IX_Like_ComentarioId",
                table: "Likes",
                newName: "IX_Likes_ComentarioId");

            migrationBuilder.AlterColumn<int>(
                name: "PostagemId",
                table: "Likes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ComentarioId",
                table: "Likes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_UsuarioId",
                table: "Likes",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Comentarios_ComentarioId",
                table: "Likes",
                column: "ComentarioId",
                principalTable: "Comentarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Postagens_PostagemId",
                table: "Likes",
                column: "PostagemId",
                principalTable: "Postagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_UsuarioId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Comentarios_ComentarioId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Postagens_PostagemId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Like");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UsuarioId",
                table: "Like",
                newName: "IX_Like_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_PostagemId",
                table: "Like",
                newName: "IX_Like_PostagemId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_ComentarioId",
                table: "Like",
                newName: "IX_Like_ComentarioId");

            migrationBuilder.AlterColumn<int>(
                name: "PostagemId",
                table: "Like",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComentarioId",
                table: "Like",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Like_AspNetUsers_UsuarioId",
                table: "Like",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Comentarios_ComentarioId",
                table: "Like",
                column: "ComentarioId",
                principalTable: "Comentarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_Postagens_PostagemId",
                table: "Like",
                column: "PostagemId",
                principalTable: "Postagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
