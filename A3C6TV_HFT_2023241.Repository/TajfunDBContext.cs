using A3C6TV_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace A3C6TV_HFT_2023241.Repository
{
    public class TajfunDBContext : DbContext
    {
        public DbSet<PoolTable> PoolTables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        Random random = new Random();

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
                        .HasOne(b => b.Customer)
                        .WithMany(c => c.Bookings)
                        .HasForeignKey(Booking => Booking.CustomerId)
                        .OnDelete(DeleteBehavior.SetNull));

            modelBuilder.Entity<Booking>(Bookings => Bookings
                        .HasOne(b => b.PoolTable)
                        .WithMany(c => c.Bookings)
                        .HasForeignKey(Booking => Booking.TableId)
                        .OnDelete(DeleteBehavior.SetNull));



            modelBuilder.Entity<Booking>().HasData(new Booking[]
            {
                new Booking(1, "2023-11-14 15:00", "2023-11-14 18:30", 14, 1),
                new Booking(2, "2023-11-14 08:00", "2023-11-14 18:30", 8, 1),
                new Booking(3, "2023-11-14 11:30", "2023-11-14 16:00", 17, 1),
                new Booking(4, "2023-11-14 16:30", "2023-11-14 20:30", 4, 1),
                new Booking(5, "2023-11-14 03:00", "2023-11-14 09:30", 5, 19),
                new Booking(6, "2023-11-14 20:30", "2023-11-14 22:00", 15, 2),
                new Booking(7, "2023-11-14 19:00", "2023-11-14 20:30", 9, 6),
                new Booking(8, "2023-11-14 07:30", "2023-11-14 13:30", 12, 18),
                new Booking(9, "2023-11-14 12:30", "2023-11-14 16:00", 3, 13),
                new Booking(10, "2023-11-14 04:30", "2023-11-14 10:00", 18, 7),
                new Booking(11, "2023-11-14 14:00", "2023-11-14 15:30", 1, 10),
                new Booking(12, "2023-11-14 12:00", "2023-11-14 17:00", 7, 8),
                new Booking(13, "2023-11-14 09:30", "2023-11-14 12:00", 6, 5),
                new Booking(14, "2023-11-14 01:00", "2023-11-14 14:30", 2, 4),
                new Booking(15, "2023-11-14 18:30", "2023-11-14 19:00", 16, 9),
                new Booking(16, "2023-11-14 10:00", "2023-11-14 12:30", 14, 11),
                new Booking(17, "2023-11-14 10:00", "2023-11-14 12:30", 8, 16),
                new Booking(18, "2023-11-14 10:00", "2023-11-14 12:30", 17, 3),
                new Booking(19, "2023-11-14 10:00", "2023-11-14 12:30", 4, 20),
                new Booking(20, "2023-11-14 10:00", "2023-11-14 12:30", 5, 19),
                new Booking(21, "2023-11-14 10:00", "2023-11-14 12:30", 15, 2),
                new Booking(22, "2023-11-14 10:00", "2023-11-14 12:30", 9, 6),
                new Booking(23, "2023-11-14 10:00", "2023-11-14 12:30", 12, 18),
                new Booking(24, "2023-11-14 10:00", "2023-11-14 12:30", 3, 13),
                new Booking(25, "2023-11-14 10:00", "2023-11-14 12:30", 18, 7),
                new Booking(26, "2023-11-14 10:00", "2023-11-14 12:30", 1, 10),
                new Booking(27, "2023-11-14 10:00", "2023-11-14 12:30", 7, 8),
                new Booking(28, "2023-11-14 10:00", "2023-11-14 12:30", 6, 5),
                new Booking(29, "2023-11-14 10:00", "2023-11-14 12:30", 2, 4),
                new Booking(30, "2023-11-14 10:00", "2023-11-14 12:30", 16, 9)
            }); ;

            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer(1,"Oláh Levente","+10000000001","asdasd1@qwert.com"),
                new Customer(2,"Szőllős Márton","+10000000002","asdasd2@qwert.com"),
                new Customer(3,"Ács Zoltán","+10000000003","asdasd3@qwert.com"),
                new Customer(4,"Farkas Gergely","+10000000004","asdasd4@qwert.com"),
                new Customer(5,"Mihály Bálint","+10000000005","asdasd5@qwert.com"),
                new Customer(6,"Emma Davis", "+1765482309", "emma.davis@example.com"),
                new Customer(7,"Michael Lee", "+1987654321", "michael.lee@example.com"),
                new Customer(8,"Olivia Miller", "+1357924680", "olivia.miller@example.com"),
                new Customer(9,"Daniel Wilson", "+1223344556", "daniel.wilson@example.com"),
                new Customer(10,"Sophia Anderson", "+1890765432", "sophia.anderson@example.com"),
                new Customer(11,"William Thomas", "+1765432987", "william.thomas@example.com"),
                new Customer(12,"Ava Garcia", "+1987654321", "ava.garcia@example.com"),
                new Customer(13,"Elijah Martinez", "+1567890123", "elijah.martinez@example.com"),
                new Customer(14,"Mia Rodriguez", "+1432547698", "mia.rodriguez@example.com"),
                new Customer(15,"James Taylor", "+1765482309", "james.taylor@example.com"),
                new Customer(16,"Sophie Moore", "+1987654321", "sophie.moore@example.com"),
                new Customer(17,"Ethan White", "+1357924680", "ethan.white@example.com"),
                new Customer(18,"Isabella Hill", "+1223344556", "isabella.hill@example.com"),
                new Customer(19,"Benjamin Clark", "+1890765432", "benjamin.clark@example.com"),
                new Customer(20,"Aria Adams", "+1765432987", "aria.adams@example.com")

            });

            modelBuilder.Entity<PoolTable>().HasData(new PoolTable[]
            {
                new PoolTable(1,"pool"),
                new PoolTable(2,"pool"),
                new PoolTable(3,"pool"),
                new PoolTable(4,"pool"),
                new PoolTable(5,"pool"),
                new PoolTable(6,"pool"),
                new PoolTable(7,"pool"),
                new PoolTable(8,"pool"),
                new PoolTable(9,"pool"),
                new PoolTable(10,"snooker"), 
                new PoolTable(11,"snooker"),
                new PoolTable(12,"snooker"),
                new PoolTable(13,"snooker"),
                new PoolTable(14,"snooker"),
                new PoolTable(15,"snooker"),
                new PoolTable(16,"snooker"),
                new PoolTable(17,"snooker"),
                new PoolTable(18,"snooker"),
                new PoolTable(19,"snooker"),
                new PoolTable(20,"snooker"),
            });

        }
    }
}
