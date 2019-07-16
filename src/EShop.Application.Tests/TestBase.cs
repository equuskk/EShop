using EShop.DataAccess;
using EShop.Domain.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Tests
{
    public class TestBase
    {
        public readonly ProductsDbContext Context;

        public ProductsDbContext GetProductsContext()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ProductsDbContext>()
                          .UseSqlite(connection)
                          .Options;

            var context = new ProductsDbContext(options);

            //  context.Database.EnsureDeleted();  
            context.Database.EnsureCreated();

            InitProductsContext(context);

            return context;
        }

        private void InitProductsContext(ProductsDbContext context)
        {
            var firstVendor = new Vendor("First Vendor", "First vendors description");
            var secondVendor = new Vendor("Second Vendor", "Second vendors description");
            context.Vendors.AddRange(firstVendor, secondVendor);

            var firstCategory = new Category("First Category");
            var secondCategory = new Category("Second Category");
            context.Categories.AddRange(firstCategory, secondCategory);

            context.SaveChanges();

            context.Products.AddRange(new Product("Продукт1", "Описание1", 111.11, 1, 1),
                                      new Product("Продукт2", "Описание2", 222.22, 2, 2));

            context.SaveChanges();
        }
    }
}