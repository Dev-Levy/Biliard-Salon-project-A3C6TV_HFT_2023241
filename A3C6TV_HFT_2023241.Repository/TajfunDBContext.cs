﻿using A3C6TV_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;

namespace A3C6TV_HFT_2023241.Repository
{
    public class TajfunDBContext : DbContext
    {
        public DbSet<PoolTable> PoolTables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public TajfunDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies()
                              .UseInMemoryDatabase("MyDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(Bookings => Bookings
                        .HasOne<Customer>()
                        .WithMany()
                        .HasForeignKey(Booking => Booking.CustomerId)
                        .OnDelete(DeleteBehavior.SetNull));

            modelBuilder.Entity<Booking>(Bookings => Bookings
                        .HasOne<PoolTable>()
                        .WithMany()
                        .HasForeignKey(Booking => Booking.TableId)
                        .OnDelete(DeleteBehavior.SetNull));



            modelBuilder.Entity<Booking>().HasData(new Booking[]
            {
                new Booking(1,"2000.10.22 15:30","2000.10.22 16:30",1,1),
                new Booking(2,"2000.10.22 15:30","2000.10.22 16:30",2,2),
                new Booking(3,"2000.10.22 16:30","2000.10.22 18:30",1,3),
                new Booking(4,"2000.10.22 16:30","2000.10.22 19:00",2,4),
            });

            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer(1,"Oláh Levente","10000000001","asdasd1@qwert.com"),
                new Customer(2,"Szőllős Márton","10000000002","asdasd2@qwert.com"),
                new Customer(3,"Ács Zoltán","10000000003","asdasd3@qwert.com"),
                new Customer(4,"Farkas Gergely","10000000004","asdasd4@qwert.com"),
                new Customer(5,"Mihály Bálint","10000000005","asdasd5@qwert.com"),
            });

            modelBuilder.Entity<PoolTable>().HasData(new PoolTable[]
            {
                new PoolTable(1,"pool"),
                new PoolTable(2,"pool"),
                new PoolTable(3,"pool"),
                new PoolTable(4,"snooker"),
                new PoolTable(5,"snooker"),
                new PoolTable(6,"snooker"),
            });

        }
    }
}
