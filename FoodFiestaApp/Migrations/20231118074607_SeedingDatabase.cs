using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodFiestaApp.Migrations
{
    public partial class SeedingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "1fbbf4d3-958c-4455-9c1b-9a854e66183d", "john.doe@example.com", false, "John", "Doe", false, null, null, null, null, null, false, "120aab98-9c22-4664-a827-e5ce822635b4", false, "john.doe@example.com" },
                    { "2", 0, "933c216e-30ea-45b0-bf09-80cb8bdb4fec", "jane.smith@example.com", false, "Jane", "Smith", false, null, null, null, null, null, false, "93848e31-cea2-4302-a5a7-5a957341fb18", false, "jane.smith@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "CustomerId", "FoodImgUrl", "FoodName" },
                values: new object[,]
                {
                    { 3, null, "burger.jpg", "Burger" },
                    { 4, null, "pasta.jpg", "Pasta" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientName" },
                values: new object[,]
                {
                    { 6, "Lettuce" },
                    { 7, "Tomato" },
                    { 8, "Mayonnaise" }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CustomerId", "FoodId", "Id" },
                values: new object[,]
                {
                    { "1", 1, 1 },
                    { "1", 2, 2 },
                    { "2", 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CustomerId", "Datetime", "Text" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2023, 11, 17, 11, 46, 6, 354, DateTimeKind.Local).AddTicks(4498), "Delicious pizza!" },
                    { 2, "2", new DateTime(2023, 11, 16, 11, 46, 6, 354, DateTimeKind.Local).AddTicks(4542), "The hotdog was amazing!" }
                });

            migrationBuilder.InsertData(
                table: "FoodIngredient",
                columns: new[] { "FoodId", "IngredientId", "Id" },
                values: new object[,]
                {
                    { 3, 4, 6 },
                    { 3, 6, 7 },
                    { 3, 7, 8 },
                    { 3, 8, 9 },
                    { 4, 2, 10 },
                    { 4, 6, 11 },
                    { 4, 7, 12 }
                });

            migrationBuilder.InsertData(
                table: "History",
                columns: new[] { "CustomerId", "FoodId", "Datetime", "Id" },
                values: new object[,]
                {
                    { "1", 1, new DateTime(2023, 11, 13, 11, 46, 6, 354, DateTimeKind.Local).AddTicks(4675), 1 },
                    { "2", 2, new DateTime(2023, 11, 8, 11, 46, 6, 354, DateTimeKind.Local).AddTicks(4688), 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumns: new[] { "CustomerId", "FoodId" },
                keyValues: new object[] { "1", 1 });

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumns: new[] { "CustomerId", "FoodId" },
                keyValues: new object[] { "1", 2 });

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumns: new[] { "CustomerId", "FoodId" },
                keyValues: new object[] { "2", 3 });

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodIngredient",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "FoodIngredient",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "FoodIngredient",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "FoodIngredient",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "FoodIngredient",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "FoodIngredient",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "FoodIngredient",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "History",
                keyColumns: new[] { "CustomerId", "FoodId" },
                keyValues: new object[] { "1", 1 });

            migrationBuilder.DeleteData(
                table: "History",
                keyColumns: new[] { "CustomerId", "FoodId" },
                keyValues: new object[] { "2", 2 });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
