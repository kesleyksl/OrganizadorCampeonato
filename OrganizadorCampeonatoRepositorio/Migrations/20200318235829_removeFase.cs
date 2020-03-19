using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizadorCampeonatoRepositorio.Migrations
{
    public partial class removeFase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competidores_Fases_FaseId",
                table: "Competidores");

            migrationBuilder.AlterColumn<int>(
                name: "FaseId",
                table: "Competidores",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Competidores_Fases_FaseId",
                table: "Competidores",
                column: "FaseId",
                principalTable: "Fases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competidores_Fases_FaseId",
                table: "Competidores");

            migrationBuilder.AlterColumn<int>(
                name: "FaseId",
                table: "Competidores",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Competidores_Fases_FaseId",
                table: "Competidores",
                column: "FaseId",
                principalTable: "Fases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
