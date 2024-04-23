using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Estudios_EstudioId",
                table: "Agendamentos");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Estudios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Estudios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Estudios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "EstudioId",
                table: "Agendamentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SalaId",
                table: "Agendamentos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_SalaId",
                table: "Agendamentos",
                column: "SalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Estudios_EstudioId",
                table: "Agendamentos",
                column: "EstudioId",
                principalTable: "Estudios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Salas_SalaId",
                table: "Agendamentos",
                column: "SalaId",
                principalTable: "Salas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Estudios_EstudioId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Salas_SalaId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_SalaId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Estudios");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Estudios");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Estudios");

            migrationBuilder.DropColumn(
                name: "SalaId",
                table: "Agendamentos");

            migrationBuilder.AlterColumn<int>(
                name: "EstudioId",
                table: "Agendamentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Estudios_EstudioId",
                table: "Agendamentos",
                column: "EstudioId",
                principalTable: "Estudios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
