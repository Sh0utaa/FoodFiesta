using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodFiestaApp.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "59461fd0-7c70-419c-9b76-bc4d32488d1b", "john.doe@example.com", false, "John", "Doe", false, null, null, null, null, null, false, "31312f9d-441c-41d1-80ca-e634f5c13085", false, "JohnDoe_27" },
                    { "2", 0, "35c7ab7e-e693-4ffc-80a9-830d8ba7750e", "jane.smith@example.com", false, "Jane", "Smith", false, null, null, null, null, null, false, "a533e662-98cf-4b74-a092-c3f16ea7e6e7", false, "JaneSmith_07" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "FoodImgUrl", "FoodName", "Price" },
                values: new object[,]
                {
                    { 1, "pizza.jpg", "Pizza", 30.0 },
                    { 2, "HotDog.jpg", "HotDog", 1.5 },
                    { 3, "burger.jpg", "Burger", 10.0 },
                    { 4, "pasta.jpg", "Pasta", 6.0 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "IngredientName" },
                values: new object[,]
                {
                    { 1, "Cheese" },
                    { 2, "Tomato Sauce" },
                    { 3, "Pepperoni" },
                    { 4, "Bun" },
                    { 5, "Sausage" },
                    { 6, "Lettuce" },
                    { 7, "Tomato" },
                    { 8, "Mayonnaise" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CustomerId", "FoodId" },
                values: new object[,]
                {
                    { 1, "1", 1 },
                    { 2, "1", 2 },
                    { 3, "2", 3 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CustomerId", "Datetime", "Rating", "Text" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2023, 11, 19, 2, 6, 37, 843, DateTimeKind.Local).AddTicks(9859), null, "Delicious pizza!" },
                    { 2, "2", new DateTime(2023, 11, 18, 2, 6, 37, 843, DateTimeKind.Local).AddTicks(9887), null, "The hotdog was amazing!" }
                });

            migrationBuilder.InsertData(
                table: "FoodIngredients",
                columns: new[] { "Id", "FoodId", "IngredientId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 4 },
                    { 5, 2, 5 },
                    { 6, 3, 4 },
                    { 7, 3, 6 },
                    { 8, 3, 7 },
                    { 9, 3, 8 },
                    { 10, 4, 2 },
                    { 11, 4, 6 },
                    { 12, 4, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodIngredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodIngredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodIngredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FoodIngredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FoodIngredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FoodIngredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FoodIngredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FoodIngredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FoodIngredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FoodIngredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FoodIngredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FoodIngredients",
                keyColumn: "Id",
                keyValue: 12);

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
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2);

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
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

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
