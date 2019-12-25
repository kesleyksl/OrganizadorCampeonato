using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizadorCampeonatoRepositorio.Migrations
{
    public partial class PrimeiraMigartion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusInscricoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusInscricoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposFase",
                columns: table => new
                {
                    TipoFaseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposFase", x => x.TipoFaseId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 80, nullable: false),
                    Sexo = table.Column<string>(maxLength: 1, nullable: false),
                    Senha = table.Column<string>(maxLength: 600, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    Telefone = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosFase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FaseId = table.Column<int>(nullable: false),
                    CompetidorId = table.Column<int>(nullable: false),
                    MusicaId = table.Column<int>(nullable: false),
                    Nota = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosFase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campeonatos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campeonatos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CampeonatoId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    TipoFaseId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fases_Campeonatos_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fases_TiposFase_TipoFaseId",
                        column: x => x.TipoFaseId,
                        principalTable: "TiposFase",
                        principalColumn: "TipoFaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competidores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CampeonatoId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    FaseId = table.Column<int>(nullable: false),
                    StatusInscricaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competidores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competidores_Fases_FaseId",
                        column: x => x.FaseId,
                        principalTable: "Fases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competidores_StatusInscricoes_StatusInscricaoId",
                        column: x => x.StatusInscricaoId,
                        principalTable: "StatusInscricoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competidores_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jurados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FaseId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jurados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jurados_Fases_FaseId",
                        column: x => x.FaseId,
                        principalTable: "Fases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jurados_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Cantor = table.Column<string>(maxLength: 50, nullable: false),
                    FaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musicas_Fases_FaseId",
                        column: x => x.FaseId,
                        principalTable: "Fases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campeonatos_UsuarioId",
                table: "Campeonatos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Competidores_FaseId",
                table: "Competidores",
                column: "FaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Competidores_StatusInscricaoId",
                table: "Competidores",
                column: "StatusInscricaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Competidores_UsuarioId",
                table: "Competidores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Fases_CampeonatoId",
                table: "Fases",
                column: "CampeonatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fases_TipoFaseId",
                table: "Fases",
                column: "TipoFaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Jurados_FaseId",
                table: "Jurados",
                column: "FaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Jurados_UsuarioId",
                table: "Jurados",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Musicas_FaseId",
                table: "Musicas",
                column: "FaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competidores");

            migrationBuilder.DropTable(
                name: "Jurados");

            migrationBuilder.DropTable(
                name: "Musicas");

            migrationBuilder.DropTable(
                name: "UsuariosFase");

            migrationBuilder.DropTable(
                name: "StatusInscricoes");

            migrationBuilder.DropTable(
                name: "Fases");

            migrationBuilder.DropTable(
                name: "Campeonatos");

            migrationBuilder.DropTable(
                name: "TiposFase");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
