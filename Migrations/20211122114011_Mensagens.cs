using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class Mensagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    corpoMensagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataEnvio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    autorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    alvoId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mensagens_AspNetUsers_alvoId",
                        column: x => x.alvoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensagens_AspNetUsers_autorId",
                        column: x => x.autorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_alvoId",
                table: "Mensagens",
                column: "alvoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_autorId",
                table: "Mensagens",
                column: "autorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mensagens");
        }
    }
}
