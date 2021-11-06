using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class Game_Characteristics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desenvolvedor",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkVideo",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Publisher",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desenvolvedor",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "LinkVideo",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Publisher",
                table: "Game");
        }
    }
}
