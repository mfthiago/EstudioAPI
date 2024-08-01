using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CheckInOut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ead34bd-19c3-4511-af26-24fa268b6d0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69353740-db20-4cd7-9be1-98ca4bbbd2bc");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckIn",
                table: "Estudios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckOut",
                table: "Estudios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "124387b7-d88d-4ab1-9c1c-dce557949c9d", null, "User", "USER" },
                    { "20d7198b-8542-4731-92ca-ced2004a4dcf", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "124387b7-d88d-4ab1-9c1c-dce557949c9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20d7198b-8542-4731-92ca-ced2004a4dcf");

            migrationBuilder.DropColumn(
                name: "CheckIn",
                table: "Estudios");

            migrationBuilder.DropColumn(
                name: "CheckOut",
                table: "Estudios");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ead34bd-19c3-4511-af26-24fa268b6d0f", null, "User", "USER" },
                    { "69353740-db20-4cd7-9be1-98ca4bbbd2bc", null, "Admin", "ADMIN" }
                });
        }
    }
}
