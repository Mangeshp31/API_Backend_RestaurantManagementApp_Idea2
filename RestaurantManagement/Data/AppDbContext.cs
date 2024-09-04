using Microsoft.EntityFrameworkCore;
using RestaurantManagementApp.Models.Domain;

namespace RestaurantManagementApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<TableReservation> TableReservations { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TableReservation configuration
            modelBuilder.Entity<TableReservation>()
                .HasOne(tr => tr.Customer)
                .WithMany(c => c.TableReservations)
                .HasForeignKey(tr => tr.CustomerID)
                .OnDelete(DeleteBehavior.Cascade); // Keeps cascade delete for Customer

            modelBuilder.Entity<TableReservation>()
                .HasOne(tr => tr.Restaurant)
                .WithMany(r => r.TableReservations)
                .HasForeignKey(tr => tr.RestaurantID)
                .OnDelete(DeleteBehavior.NoAction); // Prevents cascade delete for Restaurant

            modelBuilder.Entity<TableReservation>()
                .HasOne(tr => tr.Table)
                .WithMany(t => t.TableReservations)
                .HasForeignKey(tr => tr.TableID)
                .OnDelete(DeleteBehavior.NoAction); // Prevents cascade delete for Table

            // Orders configuration
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID)
                .OnDelete(DeleteBehavior.Cascade); // Keeps cascade delete for Customer

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Restaurant)
                .WithMany(r => r.Orders)
                .HasForeignKey(o => o.RestaurantID)
                .OnDelete(DeleteBehavior.NoAction); // Prevents cascade delete for Restaurant

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Table)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TableID)
                .OnDelete(DeleteBehavior.NoAction); // Prevents cascade delete for Table

            /////////
            ///// OrderDetail configuration
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderID)
                .OnDelete(DeleteBehavior.NoAction); // Prevents cascading delete

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.MenuItem)
                .WithMany(mi => mi.OrderDetails)
                .HasForeignKey(od => od.MenuItemID)
                .OnDelete(DeleteBehavior.Cascade); // Cascading delete allowed

            // Orders configuration
            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Customer)
            //    .WithMany(c => c.Orders)
            //    .HasForeignKey(o => o.CustomerID)
            //    .OnDelete(DeleteBehavior.Cascade); // This is fine if there is only one cascade path

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Restaurant)
            //    .WithMany(r => r.Orders)
            //    .HasForeignKey(o => o.RestaurantID)
            //    .OnDelete(DeleteBehavior.NoAction); // Prevents cascading delete to avoid conflicts

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Table)
            //    .WithMany(t => t.Orders)
            //    .HasForeignKey(o => o.TableID)
            //    .OnDelete(DeleteBehavior.NoAction); // Prevents cascading delete to avoid conflicts


            base.OnModelCreating(modelBuilder);
        }


    }
}
