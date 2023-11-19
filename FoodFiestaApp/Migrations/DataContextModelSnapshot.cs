﻿// <auto-generated />
using System;
using FoodFiestaApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodFiestaApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodFiestaApp.Models.Cart", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("CustomerId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("Cart");

                    b.HasData(
                        new
                        {
                            CustomerId = "1",
                            FoodId = 1,
                            Id = 1
                        },
                        new
                        {
                            CustomerId = "1",
                            FoodId = 2,
                            Id = 2
                        },
                        new
                        {
                            CustomerId = "2",
                            FoodId = 3,
                            Id = 3
                        });
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = "1",
                            Datetime = new DateTime(2023, 11, 18, 21, 35, 24, 669, DateTimeKind.Local).AddTicks(6033),
                            Text = "Delicious pizza!"
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = "2",
                            Datetime = new DateTime(2023, 11, 17, 21, 35, 24, 669, DateTimeKind.Local).AddTicks(6062),
                            Text = "The hotdog was amazing!"
                        });
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "322e2a0a-8856-4355-b1f9-700f7070ddb5",
                            Email = "john.doe@example.com",
                            EmailConfirmed = false,
                            FirstName = "John",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1aeddb60-02e6-4f3c-b11f-76efe0251877",
                            TwoFactorEnabled = false,
                            UserName = "JohnDoe_27"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "722ab4e5-937b-446f-bbdf-ff8aa421b8c4",
                            Email = "jane.smith@example.com",
                            EmailConfirmed = false,
                            FirstName = "Jane",
                            LastName = "Smith",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2698f581-6358-412b-b39c-3b6e60d1b142",
                            TwoFactorEnabled = false,
                            UserName = "JaneSmith_07"
                        });
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FoodImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Foods");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FoodImgUrl = "pizza.jpg",
                            FoodName = "Pizza",
                            Price = 30.0
                        },
                        new
                        {
                            Id = 2,
                            FoodImgUrl = "HotDog.jpg",
                            FoodName = "HotDog",
                            Price = 1.5
                        },
                        new
                        {
                            Id = 3,
                            FoodImgUrl = "burger.jpg",
                            FoodName = "Burger",
                            Price = 10.0
                        },
                        new
                        {
                            Id = 4,
                            FoodImgUrl = "pasta.jpg",
                            FoodName = "Pasta",
                            Price = 6.0
                        });
                });

            modelBuilder.Entity("FoodFiestaApp.Models.FoodIngredient", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("FoodId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("FoodIngredients");

                    b.HasData(
                        new
                        {
                            FoodId = 1,
                            IngredientId = 1,
                            Id = 1
                        },
                        new
                        {
                            FoodId = 1,
                            IngredientId = 2,
                            Id = 2
                        },
                        new
                        {
                            FoodId = 1,
                            IngredientId = 3,
                            Id = 3
                        },
                        new
                        {
                            FoodId = 2,
                            IngredientId = 4,
                            Id = 4
                        },
                        new
                        {
                            FoodId = 2,
                            IngredientId = 5,
                            Id = 5
                        },
                        new
                        {
                            FoodId = 3,
                            IngredientId = 4,
                            Id = 6
                        },
                        new
                        {
                            FoodId = 3,
                            IngredientId = 6,
                            Id = 7
                        },
                        new
                        {
                            FoodId = 3,
                            IngredientId = 7,
                            Id = 8
                        },
                        new
                        {
                            FoodId = 3,
                            IngredientId = 8,
                            Id = 9
                        },
                        new
                        {
                            FoodId = 4,
                            IngredientId = 2,
                            Id = 10
                        },
                        new
                        {
                            FoodId = 4,
                            IngredientId = 6,
                            Id = 11
                        },
                        new
                        {
                            FoodId = 4,
                            IngredientId = 7,
                            Id = 12
                        });
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IngredientName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IngredientName = "Cheese"
                        },
                        new
                        {
                            Id = 2,
                            IngredientName = "Tomato Sauce"
                        },
                        new
                        {
                            Id = 3,
                            IngredientName = "Pepperoni"
                        },
                        new
                        {
                            Id = 4,
                            IngredientName = "Bun"
                        },
                        new
                        {
                            Id = 5,
                            IngredientName = "Sausage"
                        },
                        new
                        {
                            Id = 6,
                            IngredientName = "Lettuce"
                        },
                        new
                        {
                            Id = 7,
                            IngredientName = "Tomato"
                        },
                        new
                        {
                            Id = 8,
                            IngredientName = "Mayonnaise"
                        });
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Cart", b =>
                {
                    b.HasOne("FoodFiestaApp.Models.Customer", "Customer")
                        .WithMany("Cart")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodFiestaApp.Models.Food", "Food")
                        .WithMany("Cart")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Comment", b =>
                {
                    b.HasOne("FoodFiestaApp.Models.Customer", "Customer")
                        .WithMany("Comments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FoodFiestaApp.Models.FoodIngredient", b =>
                {
                    b.HasOne("FoodFiestaApp.Models.Food", "Food")
                        .WithMany("FoodIngredientTable")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodFiestaApp.Models.Ingredient", "Ingredient")
                        .WithMany("FoodIngredientTable")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Customer", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Food", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("FoodIngredientTable");
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Ingredient", b =>
                {
                    b.Navigation("FoodIngredientTable");
                });
#pragma warning restore 612, 618
        }
    }
}
