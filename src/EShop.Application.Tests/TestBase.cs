using System;
using EShop.DataAccess;
using EShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Tests
{
    public class TestBase
    {
        public ProductsDbContext GetDbContext()
        {
            var builder = new DbContextOptionsBuilder<ProductsDbContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            var context = new ProductsDbContext(builder.Options);

            context.Database.EnsureCreated();
            InitProducts(context);

            return context;
        }

        private void InitProducts(ProductsDbContext context)
        {
            context.AddRange(new Product
                    {
                        Title = "�������1",
                        Description = "��������1",
                        Price = 111.11
                    },
                    new Product
                    {
                        Title = "�������2",
                        Description = "��������2",
                        Price = 222.22
                    });

            context.SaveChanges();
        }
    }
}