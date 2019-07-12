using EShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShop.DataAccess
{
    public class ProductsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
        }
    }
}