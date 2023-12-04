﻿// <auto-generated />
using System;
using FoodFiestaApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodFiestaApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231204190502_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodFiestaApp.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("userId");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FoodId = 1,
                            userId = 1
                        },
                        new
                        {
                            Id = 2,
                            FoodId = 2,
                            userId = 2
                        });
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Datetime = new DateTime(2023, 12, 4, 23, 5, 1, 494, DateTimeKind.Local).AddTicks(4283),
                            Rating = 4.5,
                            Text = "Delicious pizza!",
                            userId = 1
                        },
                        new
                        {
                            Id = 2,
                            Datetime = new DateTime(2023, 12, 4, 23, 5, 1, 494, DateTimeKind.Local).AddTicks(4310),
                            Rating = 5.0,
                            Text = "Great burger!",
                            userId = 2
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
                            Price = 10.99
                        },
                        new
                        {
                            Id = 2,
                            FoodImgUrl = "burger.jpg",
                            FoodName = "Burger",
                            Price = 8.9900000000000002
                        });
                });

            modelBuilder.Entity("FoodFiestaApp.Models.FoodIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("IngredientId");

                    b.ToTable("FoodIngredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FoodId = 1,
                            IngredientId = 1
                        },
                        new
                        {
                            Id = 2,
                            FoodId = 1,
                            IngredientId = 2
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
                            IngredientName = "Salt"
                        },
                        new
                        {
                            Id = 2,
                            IngredientName = "Pepper"
                        });
                });

            modelBuilder.Entity("FoodFiestaApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Username = "User1"
                        },
                        new
                        {
                            Id = 2,
                            Username = "User2"
                        });
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Cart", b =>
                {
                    b.HasOne("FoodFiestaApp.Models.Food", "Food")
                        .WithMany("Cart")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodFiestaApp.Models.User", "User")
                        .WithMany("Cart")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Comment", b =>
                {
                    b.HasOne("FoodFiestaApp.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("userId");

                    b.Navigation("User");
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

            modelBuilder.Entity("FoodFiestaApp.Models.Food", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("FoodIngredientTable");
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Ingredient", b =>
                {
                    b.Navigation("FoodIngredientTable");
                });

            modelBuilder.Entity("FoodFiestaApp.Models.User", b =>
                {
                    b.Navigation("Cart");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
