using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class RefatoracaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dinheiro",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "LinkBanner",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkBanner",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<double>(
                name: "Dinheiro",
                table: "AspNetUsers",
                type: "float",
                nullable: true);
        }
    }
}
