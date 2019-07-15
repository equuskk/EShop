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

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}