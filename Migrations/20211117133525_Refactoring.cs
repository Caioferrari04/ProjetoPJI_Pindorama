using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class Refactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_UserAntigo_UserAntigoId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "UserAntigo");

            migrationBuilder.DropIndex(
                name: "IX_Game_UserAntigoId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "UserAntigoId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAntigoId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserAntigo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dinheiro = table.Column<double>(type: "float", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkImagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAntigo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_UserAntigoId",
                table: "Game",
                column: "UserAntigoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_UserAntigo_UserAntigoId",
                table: "Game",
                column: "UserAntigoId",
                principalTable: "UserAntigo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
