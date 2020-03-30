using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizadorCampeonatoRepositorio.Migrations
{
    public partial class ajusteUsuarioFase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Competidores_CampeonatoId",
                table: "Competidores",
                column: "CampeonatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competidores_Campeonatos_CampeonatoId",
                table: "Competidores",
                column: "CampeonatoId",
                principalTable: "Campeonatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competidores_Campeonatos_CampeonatoId",
                table: "Competidores");

            migrationBuilder.DropIndex(
                name: "IX_Competidores_CampeonatoId",
                table: "Competidores");
        }
    }
}
