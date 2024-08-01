using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CheckInOutInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "124387b7-d88d-4ab1-9c1c-dce557949c9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20d7198b-8542-4731-92ca-ced2004a4dcf");

            migrationBuilder.AlterColumn<int>(
                name: "CheckOut",
                table: "Estudios",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "CheckIn",
                table: "Estudios",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6cd45719-f48e-4b15-8271-1d6a3f611eca", null, "User", "USER" },
                    { "be0035f0-dcac-48f2-ac13-8a5acc008d14", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cd45719-f48e-4b15-8271-1d6a3f611eca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be0035f0-dcac-48f2-ac13-8a5acc008d14");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckOut",
                table: "Estudios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckIn",
                table: "Estudios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "124387b7-d88d-4ab1-9c1c-dce557949c9d", null, "User", "USER" },
                    { "20d7198b-8542-4731-92ca-ced2004a4dcf", null, "Admin", "ADMIN" }
                });
        }
    }
}
