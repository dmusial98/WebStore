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
    [Migration("20220106223454_product-namepath")]
    partial class productnamepath
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebStore.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OvercategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OvercategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rakietki",
                            NamePath = "rakietki"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Stoły do gry",
                            NamePath = "stoly-do-gry"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Okładziny",
                            NamePath = "okladziny"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Deski",
                            NamePath = "deski"
                        });
                });

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

                    b.Property<int>("Rating")
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
                            Rating = 4
                        },
                        new
                        {
                            Id = 2,
                            Content = "Wszystko w jak największym porządku",
                            CriticId = 1,
                            ProductId = 1,
                            Rating = 5
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

                    b.Property<double>("AverageRating")
                        .HasColumnType("float");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 25,
                            AverageRating = 4.5,
                            CategoryId = 1,
                            Description = "Amatorska rakietka do gry w tenisa stołowego firmy Donic",
                            Name = "Rakietka Donic Waldner 2000",
                            NamePath = "rakietka-donic-waldner-2000",
                            Price = 100
                        },
                        new
                        {
                            Id = 2,
                            Amount = 5,
                            AverageRating = 0.0,
                            CategoryId = 2,
                            Description = "Stół do gry w tenisa stołowego Joma",
                            Name = "Stół do tenisa stolowego Joma 3250",
                            NamePath = "stol-do-tenisa-stolowego-joma-3250",
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

            modelBuilder.Entity("WebStore.Data.Entities.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Store");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "ul. Poziomkowa 88 24-987 Warszawa"
                        });
                });

            modelBuilder.Entity("WebStore.Data.Entities.StoreDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescriptionText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId")
                        .IsUnique();

                    b.ToTable("StoreDescription");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DescriptionText = "Nasz sklep zajmuje się sprzedażą sprzętu sportowego, mamy wieloletnie doświadczeniue w dostosowywaniu oferty do potrzeb klienta.",
                            StoreId = 1
                        });
                });

            modelBuilder.Entity("WebStore.Data.Entities.StoreEMail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreEMail");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmailContent = "good.store@gmail.com",
                            StoreId = 1
                        },
                        new
                        {
                            Id = 2,
                            EmailContent = "dobry.sklep@gmail.com",
                            StoreId = 1
                        });
                });

            modelBuilder.Entity("WebStore.Data.Entities.StoreHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CloseHour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<string>("OpenHour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreHours");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CloseHour = "16:00",
                            Day = 1,
                            OpenHour = "8:00",
                            StoreId = 1
                        },
                        new
                        {
                            Id = 2,
                            CloseHour = "16:00",
                            Day = 2,
                            OpenHour = "8:00",
                            StoreId = 1
                        },
                        new
                        {
                            Id = 3,
                            CloseHour = "16:00",
                            Day = 3,
                            OpenHour = "8:00",
                            StoreId = 1
                        },
                        new
                        {
                            Id = 4,
                            CloseHour = "16:00",
                            Day = 4,
                            OpenHour = "8:00",
                            StoreId = 1
                        },
                        new
                        {
                            Id = 5,
                            CloseHour = "16:00",
                            Day = 5,
                            OpenHour = "8:00",
                            StoreId = 1
                        },
                        new
                        {
                            Id = 6,
                            CloseHour = "16:00",
                            Day = 6,
                            OpenHour = "8:00",
                            StoreId = 1
                        });
                });

            modelBuilder.Entity("WebStore.Data.Entities.StoreTelephoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<string>("TelephoneNumberContent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("StoreTelephoneNumber");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StoreId = 1,
                            TelephoneNumberContent = "+48 123 456 789"
                        },
                        new
                        {
                            Id = 2,
                            StoreId = 1,
                            TelephoneNumberContent = "+48 32 12 36 647"
                        });
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

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsAdmin = true,
                            Login = "admin1",
                            Password = "strongPassword1",
                            RefreshTokenExpiryTime = new DateTime(2022, 1, 6, 23, 34, 53, 551, DateTimeKind.Local).AddTicks(2109)
                        },
                        new
                        {
                            Id = 2,
                            Address = "pl. Piłsudskiego 1/3 11-111 Ząbkowice",
                            IsAdmin = false,
                            Login = "user1",
                            Password = "strongPassword2",
                            RefreshTokenExpiryTime = new DateTime(2022, 1, 6, 23, 34, 53, 554, DateTimeKind.Local).AddTicks(4764)
                        });
                });

            modelBuilder.Entity("WebStore.Data.Entities.Category", b =>
                {
                    b.HasOne("WebStore.Data.Entities.Category", "Overcategory")
                        .WithMany()
                        .HasForeignKey("OvercategoryId");

                    b.Navigation("Overcategory");
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

            modelBuilder.Entity("WebStore.Data.Entities.Product", b =>
                {
                    b.HasOne("WebStore.Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
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

            modelBuilder.Entity("WebStore.Data.Entities.StoreDescription", b =>
                {
                    b.HasOne("WebStore.Data.Entities.Store", null)
                        .WithOne("StoreDescription")
                        .HasForeignKey("WebStore.Data.Entities.StoreDescription", "StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebStore.Data.Entities.StoreEMail", b =>
                {
                    b.HasOne("WebStore.Data.Entities.Store", null)
                        .WithMany("EMails")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebStore.Data.Entities.StoreHours", b =>
                {
                    b.HasOne("WebStore.Data.Entities.Store", null)
                        .WithMany("StoreOpenedHours")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebStore.Data.Entities.StoreTelephoneNumber", b =>
                {
                    b.HasOne("WebStore.Data.Entities.Store", null)
                        .WithMany("TelephoneNumbers")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebStore.Data.Entities.Product", b =>
                {
                    b.Navigation("Opinions");
                });

            modelBuilder.Entity("WebStore.Data.Entities.Store", b =>
                {
                    b.Navigation("EMails");

                    b.Navigation("StoreDescription");

                    b.Navigation("StoreOpenedHours");

                    b.Navigation("TelephoneNumbers");
                });

            modelBuilder.Entity("WebStore.Data.Entities.User", b =>
                {
                    b.Navigation("ProductsInCart");
                });
#pragma warning restore 612, 618
        }
    }
}
