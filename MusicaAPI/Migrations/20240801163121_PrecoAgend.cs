using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class PrecoAgend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aba9ff6-0101-4a62-bf6f-8bfaefd6a3be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94f366f3-ceb7-4c32-a61c-01e1b21e072c");

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Agendamentos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59c595a4-35b5-4049-9edd-493693b3a17a", null, "Admin", "ADMIN" },
                    { "649435dc-891f-4b80-9556-c7291577ac03", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59c595a4-35b5-4049-9edd-493693b3a17a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "649435dc-891f-4b80-9556-c7291577ac03");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Agendamentos");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3aba9ff6-0101-4a62-bf6f-8bfaefd6a3be", null, "Admin", "ADMIN" },
                    { "94f366f3-ceb7-4c32-a61c-01e1b21e072c", null, "User", "USER" }
                });
        }
    }
}
