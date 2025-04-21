using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Web_ASP_NET.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tắt cascade delete cho UserId trong OrderDetails
            modelBuilder.Entity<OrderDetail>()
                .HasRequired(od => od.User)
                .WithMany()
                .HasForeignKey(od => od.UserId)
                .WillCascadeOnDelete(false);

            // Giữ cascade delete cho OrderId và ProductId trong OrderDetails
            modelBuilder.Entity<OrderDetail>()
                .HasRequired(od => od.Order)
                .WithMany()
                .HasForeignKey(od => od.OrderId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<OrderDetail>()
                .HasRequired(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId)
                .WillCascadeOnDelete(true);

            // Giữ cascade delete cho UserId trong Orders
            modelBuilder.Entity<Order>()
                .HasRequired(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .WillCascadeOnDelete(true);
        }
    }
}