using A3C6TV_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;

namespace A3C6TV_HFT_2023241.Repository
{
    public class TajfunDBContext : DbContext
    {
        public DbSet<PoolTable> PoolTables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Consumable> Consumables { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public TajfunDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = "";

                optionsBuilder.UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // I have no idea if this works or not
        {
            modelBuilder.Entity<Booking>(Bookings => Bookings
                        .HasOne<Customer>()
                        .WithMany()
                        .HasForeignKey(Booking => Booking.Customer_ID)
                        .OnDelete(DeleteBehavior.SetNull));

            modelBuilder.Entity<Booking>(Bookings => Bookings
                        .HasOne<PoolTable>()
                        .WithMany()
                        .HasForeignKey(Booking => Booking.Table_ID)
                        .OnDelete(DeleteBehavior.SetNull));

                                                                          // Ide kell DBSeed majd
        }
    }
}
