using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodFiestaApp.Migrations
{
    public partial class updateFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoodImgUrl",
                table: "Foods",
                newName: "FilePath");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2023, 12, 5, 18, 5, 55, 288, DateTimeKind.Local).AddTicks(5278));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2023, 12, 5, 18, 5, 55, 288, DateTimeKind.Local).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "FilePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "FilePath",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Foods",
                newName: "FoodImgUrl");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Datetime",
                value: new DateTime(2023, 12, 5, 15, 6, 6, 677, DateTimeKind.Local).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Datetime",
                value: new DateTime(2023, 12, 5, 15, 6, 6, 677, DateTimeKind.Local).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "FoodImgUrl",
                value: "pizza.jpg");

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "FoodImgUrl",
                value: "burger.jpg");
        }
    }
}
