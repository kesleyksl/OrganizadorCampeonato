using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizadorCampeonatoRepositorio.Migrations
{
    public partial class CargaTipoFaseEStatusInscrica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StatusInscricoes",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Confirmado" },
                    { 2, "Pendente" },
                    { 3, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "TiposFase",
                columns: new[] { "TipoFaseId", "Nome" },
                values: new object[,]
                {
                    { 1, "JackAndJill" },
                    { 2, "Improviso" },
                    { 3, "Coreografia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatusInscricoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusInscricoes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatusInscricoes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TiposFase",
                keyColumn: "TipoFaseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposFase",
                keyColumn: "TipoFaseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposFase",
                keyColumn: "TipoFaseId",
                keyValue: 3);
        }
    }
}
