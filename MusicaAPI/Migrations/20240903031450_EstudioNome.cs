using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class EstudioNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59c595a4-35b5-4049-9edd-493693b3a17a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "649435dc-891f-4b80-9556-c7291577ac03");

            migrationBuilder.AddColumn<string>(
                name: "EstudioNome",
                table: "Agendamentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e6c779d-6d09-482f-994a-89ec4bc3c3a5", null, "Admin", "ADMIN" },
                    { "6e866f6e-988f-49b0-a7e6-27e1b39be878", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e6c779d-6d09-482f-994a-89ec4bc3c3a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e866f6e-988f-49b0-a7e6-27e1b39be878");

            migrationBuilder.DropColumn(
                name: "EstudioNome",
                table: "Agendamentos");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59c595a4-35b5-4049-9edd-493693b3a17a", null, "Admin", "ADMIN" },
                    { "649435dc-891f-4b80-9556-c7291577ac03", null, "User", "USER" }
                });
        }
    }
}
