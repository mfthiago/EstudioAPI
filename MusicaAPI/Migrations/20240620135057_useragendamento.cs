using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class useragendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13c649b7-e518-46f8-a33b-2ec9b550b652");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d00f6be-15a5-4d96-9871-5b0991ee43ad");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Agendamentos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserName",
                table: "Agendamentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ead34bd-19c3-4511-af26-24fa268b6d0f", null, "User", "USER" },
                    { "69353740-db20-4cd7-9be1-98ca4bbbd2bc", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_AppUserId",
                table: "Agendamentos",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_AspNetUsers_AppUserId",
                table: "Agendamentos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_AspNetUsers_AppUserId",
                table: "Agendamentos");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_AppUserId",
                table: "Agendamentos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ead34bd-19c3-4511-af26-24fa268b6d0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69353740-db20-4cd7-9be1-98ca4bbbd2bc");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "AppUserName",
                table: "Agendamentos");

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AgendamentoId = table.Column<int>(type: "int", nullable: false),
                    AppUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    SalaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => new { x.AppUserId, x.AgendamentoId });
                    table.ForeignKey(
                        name: "FK_Agendas_Agendamentos_AgendamentoId",
                        column: x => x.AgendamentoId,
                        principalTable: "Agendamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendas_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agendas_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13c649b7-e518-46f8-a33b-2ec9b550b652", null, "Admin", "ADMIN" },
                    { "9d00f6be-15a5-4d96-9871-5b0991ee43ad", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_AgendamentoId",
                table: "Agendas",
                column: "AgendamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_ClienteId",
                table: "Agendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_SalaId",
                table: "Agendas",
                column: "SalaId");
        }
    }
}
