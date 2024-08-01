using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Descricao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0429c66a-f4b5-4d1e-a271-f8d64fe2a5de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c822fcbf-5912-4fea-8384-280e6b5dd020");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Estudios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3aba9ff6-0101-4a62-bf6f-8bfaefd6a3be", null, "Admin", "ADMIN" },
                    { "94f366f3-ceb7-4c32-a61c-01e1b21e072c", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aba9ff6-0101-4a62-bf6f-8bfaefd6a3be");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94f366f3-ceb7-4c32-a61c-01e1b21e072c");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Estudios");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0429c66a-f4b5-4d1e-a271-f8d64fe2a5de", null, "Admin", "ADMIN" },
                    { "c822fcbf-5912-4fea-8384-280e6b5dd020", null, "User", "USER" }
                });
        }
    }
}
