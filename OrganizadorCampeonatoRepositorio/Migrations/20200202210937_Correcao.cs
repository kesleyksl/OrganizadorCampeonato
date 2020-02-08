using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizadorCampeonatoRepositorio.Migrations
{
    public partial class Correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campeonatos_Usuarios_UsuarioId",
                table: "Campeonatos");

            migrationBuilder.DropIndex(
                name: "IX_Campeonatos_UsuarioId",
                table: "Campeonatos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Campeonatos_UsuarioId",
                table: "Campeonatos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campeonatos_Usuarios_UsuarioId",
                table: "Campeonatos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
