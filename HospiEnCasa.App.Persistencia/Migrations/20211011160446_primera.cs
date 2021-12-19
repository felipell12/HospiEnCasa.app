using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    public partial class primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorasLaborales = table.Column<int>(type: "int", nullable: true),
                    Parentesco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    Especialidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EnfermeraId = table.Column<int>(type: "int", nullable: true),
                    MedicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personas_personas_EnfermeraId",
                        column: x => x.EnfermeraId,
                        principalTable: "personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personas_personas_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personas_personas_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "historias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_historias_personas_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "signosvitales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Signo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_signosvitales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_signosvitales_personas_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sugerenciascuidados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sugerenciascuidados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sugerenciascuidados_historias_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "historias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_historias_PacienteId",
                table: "historias",
                column: "PacienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_personas_EnfermeraId",
                table: "personas",
                column: "EnfermeraId");

            migrationBuilder.CreateIndex(
                name: "IX_personas_MedicoId",
                table: "personas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_personas_PacienteId",
                table: "personas",
                column: "PacienteId",
                unique: true,
                filter: "[PacienteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_signosvitales_PacienteId",
                table: "signosvitales",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_sugerenciascuidados_HistoriaId",
                table: "sugerenciascuidados",
                column: "HistoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "signosvitales");

            migrationBuilder.DropTable(
                name: "sugerenciascuidados");

            migrationBuilder.DropTable(
                name: "historias");

            migrationBuilder.DropTable(
                name: "personas");
        }
    }
}
