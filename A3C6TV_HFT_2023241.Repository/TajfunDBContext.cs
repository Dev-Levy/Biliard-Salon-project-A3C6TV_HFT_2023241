using A3C6TV_HFT_2023241.Models;
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
                string conn = @"Data Source=(LocalDB)\\MSSQLLocalDB;
                AttachDbFilename=|DataDirectory|\TajfunDB.mdf;
                Integrated Security=True;MultipleActiveResultSets=true";

                optionsBuilder.UseSqlServer(conn);
                //.UseInMemoryDatabase("MyDB")
                //.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                        .HasOne(b => b.Customer)
                        .WithMany()
                        .HasForeignKey(b => b.CustomerId)
                        .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Booking>()
                        .HasOne(b => b.PoolTable)
                        .WithMany()
                        .HasForeignKey(b => b.TableId)
                        .OnDelete(DeleteBehavior.SetNull);



            modelBuilder.Entity<Booking>().HasData(new Booking[]
            {
                new Booking(1, "2023-11-14 15:00", "2023-11-14 18:30", 14, 1),
                new Booking(2, "2023-11-15 08:00", "2023-11-15 18:30", 8, 1),
                new Booking(3, "2023-11-16 11:30", "2023-11-16 16:00", 17, 1),
                new Booking(4, "2023-11-17 16:30", "2023-11-17 20:30", 4, 1),
                new Booking(5, "2023-11-18 03:00", "2023-11-18 09:30", 5, 19),
                new Booking(6, "2023-11-19 20:30", "2023-11-19 22:00", 15, 2),
                new Booking(7, "2023-11-20 19:00", "2023-11-20 20:30", 9, 6),
                new Booking(8, "2023-11-21 07:30", "2023-11-21 13:30", 12, 18),
                new Booking(9, "2023-11-22 12:30", "2023-11-22 16:00", 3, 13),
                new Booking(10, "2023-11-23 04:30", "2023-11-23 10:00", 18, 7),
                new Booking(11, "2023-11-24 14:00", "2023-11-24 15:30", 1, 10),
                new Booking(12, "2023-11-25 12:00", "2023-11-25 17:00", 7, 8),
                new Booking(13, "2023-11-26 09:30", "2023-11-26 12:00", 6, 5),
                new Booking(14, "2023-11-27 01:00", "2023-11-27 14:30", 2, 4),
                new Booking(15, "2023-11-28 18:30", "2023-11-28 19:00", 16, 9),
                new Booking(16, "2023-11-29 10:00", "2023-11-29 12:30", 14, 11),
                new Booking(17, "2023-11-30 10:00", "2023-11-30 12:30", 8, 16),
                new Booking(18, "2023-12-01 10:00", "2023-12-01 12:30", 17, 3),
                new Booking(19, "2023-12-02 10:00", "2023-12-02 12:30", 4, 20),
                new Booking(20, "2023-12-03 10:00", "2023-12-03 12:30", 5, 19),
                new Booking(21, "2023-12-04 10:00", "2023-12-04 12:30", 15, 2),
                new Booking(22, "2023-12-05 10:00", "2023-12-05 12:30", 9, 6),
                new Booking(23, "2023-12-06 10:00", "2023-12-06 12:30", 12, 18),
                new Booking(24, "2023-12-07 10:00", "2023-12-07 12:30", 3, 13),
                new Booking(25, "2023-12-08 10:00", "2023-12-08 12:30", 18, 7),
                new Booking(26, "2023-12-09 10:00", "2023-12-09 12:30", 1, 10),
                new Booking(27, "2023-12-10 10:00", "2023-12-10 12:30", 7, 8),
                new Booking(28, "2023-12-11 10:00", "2023-12-11 12:30", 6, 5),
                new Booking(29, "2023-12-12 10:00", "2023-12-12 12:30", 2, 4),
                new Booking(30, "2023-12-13 10:00", "2023-12-13 12:30", 16, 9),
                new Booking(31, "2023-11-15 14:30", "2023-11-15 17:00", 11, 1),
                new Booking(32, "2023-11-15 16:00", "2023-11-15 19:30", 6, 1),
                new Booking(33, "2023-11-15 10:30", "2023-11-15 13:00", 2, 1),
                new Booking(34, "2023-11-15 19:30", "2023-11-15 21:00", 17, 1),
                new Booking(35, "2023-11-16 09:00", "2023-11-16 12:30", 8, 1),
                new Booking(36, "2023-11-16 13:30", "2023-11-16 16:00", 14, 1),
                new Booking(37, "2023-11-16 17:00", "2023-11-16 20:30", 3, 1),
                new Booking(38, "2023-11-17 11:00", "2023-11-17 14:30", 5, 1),
                new Booking(39, "2023-11-17 15:30", "2023-11-17 18:00", 19, 1),
                new Booking(40, "2023-11-17 19:00", "2023-11-17 21:30", 12, 1),


            }); ;

            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer(1,"Oláh Levente","+10000000001","asdasd1@qwert.com"),
                new Customer(2,"Szőllős Márton","+10000000002","asdasd2@qwert.com"),
                new Customer(3,"Ács Zoltán","+10000000003","asdasd3@qwert.com"),
                new Customer(4,"Farkas Gergely","+10000000004","asdasd4@qwert.com"),
                new Customer(5,"Mihály Bálint","+10000000005","asdasd5@qwert.com"),
                new Customer(6,"Babos Bálint","+10000000006","asdasd6@qwert.com"),
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
                new Customer(20,"Aria Adams", "+1765432987", "aria.adams@example.com"),
                new Customer(21,"Prof. Dr. habil Litresits Ádám", "+17654378523475682", "sajt.sajt@citromail.com")

            });

            modelBuilder.Entity<PoolTable>().HasData(new PoolTable[]
            {
                new PoolTable(1,"Pool"),
                new PoolTable(2,"Pool"),
                new PoolTable(3,"Pool"),
                new PoolTable(4,"Pool"),
                new PoolTable(5,"Pool"),
                new PoolTable(6,"Pool"),
                new PoolTable(7,"Pool"),
                new PoolTable(8,"Pool"),
                new PoolTable(9,"Pool"),
                new PoolTable(10,"Pool"),
                new PoolTable(11,"Snooker"),
                new PoolTable(12,"Snooker"),
                new PoolTable(13,"Snooker"),
                new PoolTable(14,"Snooker"),
                new PoolTable(15,"Snooker"),
                new PoolTable(16,"Snooker"),
                new PoolTable(17,"Snooker"),
                new PoolTable(18,"Snooker"),
                new PoolTable(19,"Snooker"),
                new PoolTable(20,"Snooker"),
                new PoolTable(21,"Snooker"),
            });

        }
    }
}
