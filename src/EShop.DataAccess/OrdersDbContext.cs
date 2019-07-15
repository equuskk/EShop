using EShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShop.DataAccess
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductInCart> ProductsInCart { get; set; }

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}