using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class NovosCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Estudios_EstudioId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_EstudioId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "EstudioId",
                table: "Agendamentos");

            migrationBuilder.AddColumn<int>(
                name: "SalaId",
                table: "Equipamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_SalaId",
                table: "Equipamentos",
                column: "SalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamentos_Salas_SalaId",
                table: "Equipamentos",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamentos_Salas_SalaId",
                table: "Equipamentos");

            migrationBuilder.DropIndex(
                name: "IX_Equipamentos_SalaId",
                table: "Equipamentos");

            migrationBuilder.DropColumn(
                name: "SalaId",
                table: "Equipamentos");

            migrationBuilder.AddColumn<int>(
                name: "EstudioId",
                table: "Agendamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_EstudioId",
                table: "Agendamentos",
                column: "EstudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Estudios_EstudioId",
                table: "Agendamentos",
                column: "EstudioId",
                principalTable: "Estudios",
                principalColumn: "Id");
        }
    }
}
