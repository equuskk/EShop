using EShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShop.DataAccess
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductInCart> ProductsInCarts { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<ShopUser>();
            base.OnModelCreating(builder);
        }
    }
}