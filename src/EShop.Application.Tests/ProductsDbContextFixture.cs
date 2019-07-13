using System;
using EShop.DataAccess;
using EShop.Domain.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Tests
{
    public class ProductsDbContextFixture : IDisposable
    {
        public readonly ProductsDbContext Context;
        public ProductsDbContextFixture()
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

            Context = context;
        }

        private void InitProductsContext(ProductsDbContext context)
        {
            var firstVendor = new Vendor("First Vendor", "First vendors description");
            var secondVendor = new Vendor("Second Vendor", "Second vendors description");
            context.Vendors.AddRange(firstVendor, secondVendor);

            var firstCategory = new Category("First Category");
            var secondCategory = new Category("Second Category");
            context.Categories.AddRange(firstCategory, secondCategory);

            context.Products.AddRange(new Product("Продукт1", "Описание1", 111.11, firstVendor, firstCategory),
                                      new Product("Продукт2", "Описание2", 222.22, secondVendor, secondCategory));

            context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}