using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class DataFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Agendamentos",
                newName: "DataInicial");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFinal",
                table: "Agendamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFinal",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "DataInicial",
                table: "Agendamentos",
                newName: "Data");
        }
    }
}
