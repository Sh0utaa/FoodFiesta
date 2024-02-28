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
    [Migration("20240228173402_bih")]
    partial class bih
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

                    b.Property<int?>("FoodId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
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
                            Datetime = new DateTime(2024, 2, 28, 21, 34, 1, 759, DateTimeKind.Local).AddTicks(4922),
                            Rating = 4.5,
                            Text = "Comment from User1",
                            userId = 1
                        },
                        new
                        {
                            Id = 2,
                            Datetime = new DateTime(2024, 2, 28, 21, 34, 1, 759, DateTimeKind.Local).AddTicks(4937),
                            Rating = 3.0,
                            Text = "Comment from User2",
                            userId = 2
                        });
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                            FoodName = "Pizza",
                            Price = 10.99
                        },
                        new
                        {
                            Id = 2,
                            FoodName = "Pasta",
                            Price = 10.99
                        },
                        new
                        {
                            Id = 3,
                            FoodName = "Burger",
                            Price = 10.99
                        },
                        new
                        {
                            Id = 4,
                            FoodName = "Steak",
                            Price = 10.99
                        },
                        new
                        {
                            Id = 5,
                            FoodName = "Ramen",
                            Price = 10.99
                        },
                        new
                        {
                            Id = 6,
                            FoodName = "Shawarma",
                            Price = 10.99
                        },
                        new
                        {
                            Id = 7,
                            FoodName = "Sushi",
                            Price = 10.99
                        },
                        new
                        {
                            Id = 8,
                            FoodName = "Cheesecake",
                            Price = 10.99
                        },
                        new
                        {
                            Id = 9,
                            FoodName = "Ceasar Salad",
                            Price = 10.99
                        },
                        new
                        {
                            Id = 10,
                            FoodName = "Mwvadi",
                            Price = 10.99
                        });
                });

            modelBuilder.Entity("FoodFiestaApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

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
                            Admin = false,
                            Email = "user1@example.com",
                            Username = "User1"
                        },
                        new
                        {
                            Id = 2,
                            Admin = false,
                            Email = "user2@example.com",
                            Username = "User2"
                        });
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Cart", b =>
                {
                    b.HasOne("FoodFiestaApp.Models.Food", "Food")
                        .WithMany("Cart")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FoodFiestaApp.Models.User", "User")
                        .WithMany("Cart")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Food");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Comment", b =>
                {
                    b.HasOne("FoodFiestaApp.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodFiestaApp.Models.Food", b =>
                {
                    b.Navigation("Cart");
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
