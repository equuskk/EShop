using EShop.DataAccess;
using EShop.Domain.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EShop.Application.Tests
{
    public class TestBase
    {
        public string UserId { get; private set; }
        private readonly ProductsDbContext ProductsContext;
        private readonly UsersDbContext UsersContext;

        public TestBase()
        {
            ProductsContext = GetProductsContext();
            UsersContext = GetUsersContext();
            InitReviewContext(ProductsContext);
        }

        public ProductsDbContext GetProductsContext()
        {
            if(ProductsContext != null)
            {
                return ProductsContext;
            }

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ProductsDbContext>()
                          .UseSqlite(connection)
                          .Options;

            var context = new ProductsDbContext(options);

            context.Database.EnsureCreated();

            InitProductsContext(context);

            return context;
        }

        public UsersDbContext GetUsersContext()
        {
            if(UsersContext != null)
            {
                return UsersContext;
            }
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<UsersDbContext>()
                          .UseSqlite(connection)
                          .Options;

            var context = new UsersDbContext(options);

            context.Database.EnsureCreated();

            InitUsersContext(context);

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

        private void InitUsersContext(UsersDbContext context)
        {
            var user = new ShopUser("test", "test", "test", "+79588332197",
                                    "test@test.com", "test");
            context.Users.Add(user);
            context.SaveChanges();

            UserId = user.Id;
        }

        private void InitReviewContext(ProductsDbContext context)
        {
            var review = new Review("Тест", 5, UserId, ProductsContext.Products.First().Id);
            context.Reviews.Add(review);

            context.SaveChanges();
        }
    }
}