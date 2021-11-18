using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class Refactoring2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amizade_AspNetUsers_AlvoId",
                table: "Amizade");

            migrationBuilder.DropForeignKey(
                name: "FK_Amizade_AspNetUsers_OrigemId",
                table: "Amizade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amizade",
                table: "Amizade");

            migrationBuilder.RenameTable(
                name: "Amizade",
                newName: "Amizades");

            migrationBuilder.RenameIndex(
                name: "IX_Amizade_AlvoId",
                table: "Amizades",
                newName: "IX_Amizades_AlvoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amizades",
                table: "Amizades",
                columns: new[] { "OrigemId", "AlvoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Amizades_AspNetUsers_AlvoId",
                table: "Amizades",
                column: "AlvoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Amizades_AspNetUsers_OrigemId",
                table: "Amizades",
                column: "OrigemId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_AspNetUsers_AlvoId",
                table: "Amizades");

            migrationBuilder.DropForeignKey(
                name: "FK_Amizades_AspNetUsers_OrigemId",
                table: "Amizades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amizades",
                table: "Amizades");

            migrationBuilder.RenameTable(
                name: "Amizades",
                newName: "Amizade");

            migrationBuilder.RenameIndex(
                name: "IX_Amizades_AlvoId",
                table: "Amizade",
                newName: "IX_Amizade_AlvoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amizade",
                table: "Amizade",
                columns: new[] { "OrigemId", "AlvoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Amizade_AspNetUsers_AlvoId",
                table: "Amizade",
                column: "AlvoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Amizade_AspNetUsers_OrigemId",
                table: "Amizade",
                column: "OrigemId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
