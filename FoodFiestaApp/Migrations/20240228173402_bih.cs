using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodFiestaApp.Migrations
{
    public partial class bih : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2024, 2, 28, 21, 34, 1, 759, DateTimeKind.Local).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2024, 2, 28, 21, 34, 1, 759, DateTimeKind.Local).AddTicks(4937));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2024, 2, 28, 21, 31, 12, 672, DateTimeKind.Local).AddTicks(6985));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2024, 2, 28, 21, 31, 12, 672, DateTimeKind.Local).AddTicks(6999));
        }
    }
}
