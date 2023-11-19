using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodFiestaApp.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    FoodImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    Datetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => new { x.CustomerId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_Cart_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodIngredients",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodIngredients", x => new { x.FoodId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_FoodIngredients_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "322e2a0a-8856-4355-b1f9-700f7070ddb5", "john.doe@example.com", false, "John", "Doe", false, null, null, null, null, null, false, "1aeddb60-02e6-4f3c-b11f-76efe0251877", false, "JohnDoe_27" },
                    { "2", 0, "722ab4e5-937b-446f-bbdf-ff8aa421b8c4", "jane.smith@example.com", false, "Jane", "Smith", false, null, null, null, null, null, false, "2698f581-6358-412b-b39c-3b6e60d1b142", false, "JaneSmith_07" }
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
                columns: new[] { "Id", "CustomerId", "Datetime", "Rating", "Text" },
                values: new object[,]
                {
                    { 1, "1", new DateTime(2023, 11, 18, 21, 35, 24, 669, DateTimeKind.Local).AddTicks(6033), null, "Delicious pizza!" },
                    { 2, "2", new DateTime(2023, 11, 17, 21, 35, 24, 669, DateTimeKind.Local).AddTicks(6062), null, "The hotdog was amazing!" }
                });

            migrationBuilder.InsertData(
                table: "FoodIngredients",
                columns: new[] { "FoodId", "IngredientId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 2 },
                    { 1, 3, 3 },
                    { 2, 4, 4 },
                    { 2, 5, 5 },
                    { 3, 4, 6 },
                    { 3, 6, 7 },
                    { 3, 7, 8 },
                    { 3, 8, 9 },
                    { 4, 2, 10 },
                    { 4, 6, 11 },
                    { 4, 7, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_FoodId",
                table: "Cart",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodIngredients_IngredientId",
                table: "FoodIngredients",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FoodIngredients");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
