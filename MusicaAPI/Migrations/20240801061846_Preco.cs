using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Preco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1431b755-4c38-4ebb-ae85-fa50c5b3614a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccf796a2-4053-428d-ad98-8e633b0486a4");

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Estudios",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0429c66a-f4b5-4d1e-a271-f8d64fe2a5de", null, "Admin", "ADMIN" },
                    { "c822fcbf-5912-4fea-8384-280e6b5dd020", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0429c66a-f4b5-4d1e-a271-f8d64fe2a5de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c822fcbf-5912-4fea-8384-280e6b5dd020");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Estudios");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1431b755-4c38-4ebb-ae85-fa50c5b3614a", null, "Admin", "ADMIN" },
                    { "ccf796a2-4053-428d-ad98-8e633b0486a4", null, "User", "USER" }
                });
        }
    }
}
