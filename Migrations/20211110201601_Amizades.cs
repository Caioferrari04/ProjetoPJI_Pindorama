using Microsoft.EntityFrameworkCore.Migrations;

namespace Pindorama.Migrations
{
    public partial class Amizades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amizade",
                columns: table => new
                {
                    OrigemId = table.Column<int>(type: "int", nullable: false),
                    AlvoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amizade", x => new { x.OrigemId, x.AlvoId });
                    table.ForeignKey(
                        name: "FK_Amizade_User_AlvoId",
                        column: x => x.AlvoId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Amizade_User_OrigemId",
                        column: x => x.OrigemId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amizade_AlvoId",
                table: "Amizade",
                column: "AlvoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amizade");
        }
    }
}
