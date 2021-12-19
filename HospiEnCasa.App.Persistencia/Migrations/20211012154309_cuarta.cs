using Microsoft.EntityFrameworkCore.Migrations;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    public partial class cuarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personas_personas_PacienteId",
                table: "personas");

            migrationBuilder.DropForeignKey(
                name: "FK_signosvitales_personas_PacienteId",
                table: "signosvitales");

            migrationBuilder.DropIndex(
                name: "IX_personas_PacienteId",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "Diagnostico",
                table: "historias");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "signosvitales",
                newName: "HistoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_signosvitales_PacienteId",
                table: "signosvitales",
                newName: "IX_signosvitales_HistoriaId");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "personas",
                newName: "FamiliarDesignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_personas_FamiliarDesignadoId",
                table: "personas",
                column: "FamiliarDesignadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_personas_personas_FamiliarDesignadoId",
                table: "personas",
                column: "FamiliarDesignadoId",
                principalTable: "personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_signosvitales_historias_HistoriaId",
                table: "signosvitales",
                column: "HistoriaId",
                principalTable: "historias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personas_personas_FamiliarDesignadoId",
                table: "personas");

            migrationBuilder.DropForeignKey(
                name: "FK_signosvitales_historias_HistoriaId",
                table: "signosvitales");

            migrationBuilder.DropIndex(
                name: "IX_personas_FamiliarDesignadoId",
                table: "personas");

            migrationBuilder.RenameColumn(
                name: "HistoriaId",
                table: "signosvitales",
                newName: "PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_signosvitales_HistoriaId",
                table: "signosvitales",
                newName: "IX_signosvitales_PacienteId");

            migrationBuilder.RenameColumn(
                name: "FamiliarDesignadoId",
                table: "personas",
                newName: "PacienteId");

            migrationBuilder.AddColumn<string>(
                name: "Diagnostico",
                table: "historias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_personas_PacienteId",
                table: "personas",
                column: "PacienteId",
                unique: true,
                filter: "[PacienteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_personas_personas_PacienteId",
                table: "personas",
                column: "PacienteId",
                principalTable: "personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_signosvitales_personas_PacienteId",
                table: "signosvitales",
                column: "PacienteId",
                principalTable: "personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
