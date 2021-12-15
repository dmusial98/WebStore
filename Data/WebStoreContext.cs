using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebStore.Data.Entities;

namespace WebStore.Data
{
    public class WebStoreContext : DbContext
    {
        private readonly IConfiguration _config;
        
        public WebStoreContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<ProductInCart> ProductsInCarts { get; set; }
        public DbSet<Store> Store { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("WebStore"));
        }


        //dopisac pojedyncze encje
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new
                {
                    Id = 1,
                    IsAdmin = true,
                    Login = "admin1",
                    Password = "strongPassword1",
                    Addres = "ul. Konwaliowa 36 27-512 Rzeszów",
                },
                new
                {
                    Id = 2,
                    IsAdmin = false,
                    Login = "user1",
                    Password = "strongPassword2",
                    Address = "pl. Piłsudskiego 1/3 11-111 Ząbkowice"
                });

            modelBuilder.Entity<Product>().HasData(
                new
                {
                    Id = 1,
                    Name = "Rakietka Donic Waldner 2000",
                    Description = "Amatorska rakietka do gry w tenisa stołowego firmy Donic",
                    Price = 100,
                    Amount = 25
                },
                new
                {
                    Id = 2,
                    Name = "Stół do tenisa stolowego Joma 3250",
                    Description = "Stół do gry w tenisa stołowego Joma",
                    Price = 2000,
                    Amount = 5,
                });

            modelBuilder.Entity<Opinion>().HasData(
                new
                {
                    Id = 1,
                    ProductId = 1,
                    Content = "Dobry stosunek jakość - cena",
                    Value = 4,
                    CriticId = 2
                },
                new 
                {
                    Id=2,
                    ProductId = 1,
                    Content = "Wszystko w jak największym porządku",
                    Value = 5,
                    CriticId = 1
                });

            modelBuilder.Entity<Store>().HasData(
                new
                {
                    Id = 1,
                    Address = "ul. Poziomkowa 88 24-987 Warszawa"
                });

            modelBuilder.Entity<StoreDescription>().HasData(
                new StoreDescription
                {
                    Id = 1,
                    StoreId = 1,
                    DescriptionText = "Nasz sklep zajmuje się sprzedażą sprzętu sportowego, mamy wieloletnie doświadczeniue w dostosowywaniu oferty do potrzeb klienta."
                });

            modelBuilder.Entity<StoreTelephoneNumber>().HasData(
                new StoreTelephoneNumber
                {
                    Id = 1, 
                    StoreId = 1,
                    TelephoneNumberContent = "+48 123 456 789"
                },
                new StoreTelephoneNumber
                {
                    Id = 2, 
                    StoreId = 1,
                    TelephoneNumberContent = "+48 32 12 36 647"
                }
            );

            modelBuilder.Entity<StoreEMail>().HasData(
                new StoreEMail
                {
                    Id = 1, 
                    StoreId = 1,
                    EmailContent = "good.store@gmail.com"
                },
                new StoreEMail
                {
                    Id = 2,
                    StoreId = 1,
                    EmailContent = "dobry.sklep@gmail.com"
                });

            modelBuilder.Entity<StoreHours>().HasData(
                new StoreHours
                {
                    Id = 1,
                    StoreId = 1,
                    Day = DayOfWeek.Monday,
                    OpenHour = "8:00",
                    CloseHour = "16:00"
                },
                new StoreHours
                {
                    Id = 2,
                    StoreId = 1,
                    Day = DayOfWeek.Tuesday,
                    OpenHour = "8:00",
                    CloseHour = "16:00"
                },
                new StoreHours
                {
                    Id = 3,
                    StoreId = 1,
                    Day = DayOfWeek.Wednesday,
                    OpenHour = "8:00",
                    CloseHour = "16:00"
                },
                new StoreHours
                {
                    Id = 4,
                    StoreId = 1,
                    Day = DayOfWeek.Thursday,
                    OpenHour = "8:00",
                    CloseHour = "16:00"
                },
                new StoreHours
                {
                    Id = 5,
                    StoreId = 1,
                    Day = DayOfWeek.Friday,
                    OpenHour = "8:00",
                    CloseHour = "16:00"
                },
                new StoreHours
                {
                    Id = 6,
                    StoreId = 1,
                    Day = DayOfWeek.Saturday,
                    OpenHour = "8:00",
                    CloseHour = "16:00"
                });

           
        }
        

    }
}
