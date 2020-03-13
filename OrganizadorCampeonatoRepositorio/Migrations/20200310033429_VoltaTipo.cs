using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizadorCampeonatoRepositorio.Migrations
{
    public partial class VoltaTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Fases_TipoFaseId",
                table: "Fases",
                column: "TipoFaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fases_TiposFase_TipoFaseId",
                table: "Fases",
                column: "TipoFaseId",
                principalTable: "TiposFase",
                principalColumn: "TipoFaseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fases_TiposFase_TipoFaseId",
                table: "Fases");

            migrationBuilder.DropIndex(
                name: "IX_Fases_TipoFaseId",
                table: "Fases");
        }
    }
}
