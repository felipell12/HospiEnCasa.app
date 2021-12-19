using Microsoft.EntityFrameworkCore.Migrations;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_historias_personas_PacienteId",
                table: "historias");

            migrationBuilder.DropForeignKey(
                name: "FK_personas_personas_EnfermeraId",
                table: "personas");

            migrationBuilder.DropForeignKey(
                name: "FK_personas_personas_MedicoId",
                table: "personas");

            migrationBuilder.DropIndex(
                name: "IX_historias_PacienteId",
                table: "historias");

            migrationBuilder.AddColumn<int>(
                name: "HistoriaId",
                table: "personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HistoriaId1",
                table: "personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_personas_HistoriaId1",
                table: "personas",
                column: "HistoriaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_personas_historias_HistoriaId1",
                table: "personas",
                column: "HistoriaId1",
                principalTable: "historias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personas_personas_EnfermeraId",
                table: "personas",
                column: "EnfermeraId",
                principalTable: "personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personas_personas_MedicoId",
                table: "personas",
                column: "MedicoId",
                principalTable: "personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personas_historias_HistoriaId1",
                table: "personas");

            migrationBuilder.DropForeignKey(
                name: "FK_personas_personas_EnfermeraId",
                table: "personas");

            migrationBuilder.DropForeignKey(
                name: "FK_personas_personas_MedicoId",
                table: "personas");

            migrationBuilder.DropIndex(
                name: "IX_personas_HistoriaId1",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "HistoriaId",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "HistoriaId1",
                table: "personas");

            migrationBuilder.CreateIndex(
                name: "IX_historias_PacienteId",
                table: "historias",
                column: "PacienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_historias_personas_PacienteId",
                table: "historias",
                column: "PacienteId",
                principalTable: "personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_personas_personas_EnfermeraId",
                table: "personas",
                column: "EnfermeraId",
                principalTable: "personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_personas_personas_MedicoId",
                table: "personas",
                column: "MedicoId",
                principalTable: "personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
