using EShop.DataAccess;
using EShop.Domain.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Tests
{
    public class TestBase
    {
        public string UserId { get; private set; }
        public readonly ApplicationDbContext ApplicationContext;

        public TestBase()
        {
            ApplicationContext = GetDbContext();
        }

        public ApplicationDbContext GetDbContext()
        {
            if(ApplicationContext != null)
            {
                return ApplicationContext;
            }

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseSqlite(connection)
                          .Options;

            var context = new ApplicationDbContext(options);

            context.Database.EnsureCreated();

            InitDbContext(context);

            return context;
        }

        private void InitDbContext(ApplicationDbContext context)
        {
            var firstVendor = new Vendor("First Vendor", "First vendors description");
            var secondVendor = new Vendor("Second Vendor", "Second vendors description");
            context.Vendors.AddRange(firstVendor, secondVendor);

            var firstCategory = new Category("First Category");
            var secondCategory = new Category("Second Category");
            context.Categories.AddRange(firstCategory, secondCategory);
            context.SaveChanges();

            var firstProduct = new Product("Продукт1", "Описание1", 111.11, 1, 1, "test/test.png");
            var secondProduct = new Product("Продукт2", "Описание2", 222.22, 2, 2, "test/test.png");
            context.Products.AddRange(firstProduct, secondProduct);
            context.SaveChanges();

            InitUsers(context);

            var review = new Review("Тест", 5, UserId, firstProduct.Id);
            context.Reviews.Add(review);

            var productInCart = new ProductInCart(UserId, firstProduct.Id, 2);
            context.ProductsInCarts.Add(productInCart);

            context.SaveChanges();
        }

        private void InitUsers(ApplicationDbContext context)
        {
            var user = new ShopUser("test", "test", "test", "+79588332197",
                                    "test@test.com", "test");
            context.Users.Add(user);
            context.SaveChanges();

            UserId = user.Id;
        }
    }
}