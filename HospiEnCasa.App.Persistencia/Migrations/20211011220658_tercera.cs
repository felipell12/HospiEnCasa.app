using Microsoft.EntityFrameworkCore.Migrations;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    public partial class tercera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personas_historias_HistoriaId1",
                table: "personas");

            migrationBuilder.DropIndex(
                name: "IX_personas_HistoriaId1",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "HistoriaId1",
                table: "personas");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "historias");

            migrationBuilder.CreateIndex(
                name: "IX_personas_HistoriaId",
                table: "personas",
                column: "HistoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_personas_historias_HistoriaId",
                table: "personas",
                column: "HistoriaId",
                principalTable: "historias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personas_historias_HistoriaId",
                table: "personas");

            migrationBuilder.DropIndex(
                name: "IX_personas_HistoriaId",
                table: "personas");

            migrationBuilder.AddColumn<int>(
                name: "HistoriaId1",
                table: "personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "historias",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
