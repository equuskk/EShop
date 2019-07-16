using EShop.DataAccess;
using EShop.Domain.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Tests
{
    public class TestBase
    {
        public string UserId { get; private set; }
        public readonly ProductsDbContext ProductsContext;
        public readonly UsersDbContext UsersContext;

        public TestBase()
        {
            UsersContext = GetUsersContext();
            ProductsContext = GetProductsContext();
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

            var firstProduct = new Product("Продукт1", "Описание1", 111.11, 1, 1);
            var secondProduct = new Product("Продукт2", "Описание2", 222.22, 2, 2);
            context.Products.AddRange(firstProduct, secondProduct);
            context.SaveChanges();

            var review = new Review("Тест", 5, UserId, firstProduct.Id);
            context.Reviews.Add(review);

            var productInCart = new ProductInCart(UserId, firstProduct.Id, 2);
            context.ProductsInCarts.Add(productInCart);

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
    }
}