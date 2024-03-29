﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebStore.Data;

namespace WebStore.Migrations
{
    [DbContext(typeof(WebStoreContext))]
    [Migration("20211213120948_store-added")]
    partial class storeadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebStore.Data.Entities.Opinion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CriticId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CriticId");

                    b.HasIndex("ProductId");

                    b.ToTable("Opinions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Dobry stosunek jakość - cena",
                            CriticId = 2,
                            ProductId = 1,
                            Value = 4
                        },
                        new
                        {
                            Id = 2,
                            Content = "Wszystko w jak największym porządku",
                            CriticId = 1,
                            ProductId = 1,
                            Value = 5
                        });
                });

            modelBuilder.Entity("WebStore.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 25,
                            Description = "Amatorska rakietka do gry w tenisa stołowego firmy Donic",
                            Name = "Rakietka Donic Waldner 2000",
                            Price = 100
                        },
                        new
                        {
                            Id = 2,
                            Amount = 5,
                            Description = "Stół do gry w tenisa stołowego Joma",
                            Name = "Stół do tenisa stolowego Joma 3250",
                            Price = 2000
                        });
                });

            modelBuilder.Entity("WebStore.Data.Entities.ProductInCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductsInCarts");
                });

            modelBuilder.Entity("WebStore.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAdmin = true,
                            Login = "admin1",
                            Password = "strongPassword1"
                        },
                        new
                        {
                            Id = 2,
                            Address = "pl. Piłsudskiego 1/3 11-111 Ząbkowice",
                            IsAdmin = false,
                            Login = "user1",
                            Password = "strongPassword2"
                        });
                });

            modelBuilder.Entity("WebStore.Data.Entities.Opinion", b =>
                {
                    b.HasOne("WebStore.Data.Entities.User", "Critic")
                        .WithMany()
                        .HasForeignKey("CriticId");

                    b.HasOne("WebStore.Data.Entities.Product", null)
                        .WithMany("Opinions")
                        .HasForeignKey("ProductId");

                    b.Navigation("Critic");
                });

            modelBuilder.Entity("WebStore.Data.Entities.ProductInCart", b =>
                {
                    b.HasOne("WebStore.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("WebStore.Data.Entities.User", null)
                        .WithMany("ProductsInCart")
                        .HasForeignKey("UserId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebStore.Data.Entities.Product", b =>
                {
                    b.Navigation("Opinions");
                });

            modelBuilder.Entity("WebStore.Data.Entities.User", b =>
                {
                    b.Navigation("ProductsInCart");
                });
#pragma warning restore 612, 618
        }
    }
}
