using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Context;

public class ShopContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Roles> Roles { get; set; } = null!;
        public DbSet<Accounts> Accounts { get; set; } = null!;
        public DbSet<Products> Products { get; set; } = null!;
        public DbSet<Categories> Categories { get; set; } = null!;
        public DbSet<Products_Categories> ProductsCategories { get; set; } = null!;
        public DbSet<Shopping_Carts> ShoppingCarts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=master;User Id=SA;Password=yourStrong(!)Password;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products_Categories>()
                .HasKey(pc => new { pc.FK_product, pc.FK_category });

            modelBuilder.Entity<Products_Categories>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductsCategories)
                .HasForeignKey(pc => pc.FK_product);

            modelBuilder.Entity<Products_Categories>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductsCategories)
                .HasForeignKey(pc => pc.FK_category);

            modelBuilder.Entity<Shopping_Carts>()
                .HasKey(sc => new { sc.FK_account, sc.FK_product });

            modelBuilder.Entity<Shopping_Carts>()
                .HasOne(sc => sc.Account)
                .WithMany(a => a.ShoppingCarts)
                .HasForeignKey(sc => sc.FK_account);

            modelBuilder.Entity<Shopping_Carts>()
                .HasOne(sc => sc.Product)
                .WithMany(p => p.ShoppingCarts)
                .HasForeignKey(sc => sc.FK_product);
        }
    }
}