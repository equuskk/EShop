using System.Threading;
using EShop.Application.Products.Commands.AddProduct;
using EShop.DataAccess;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class AddProductTests : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public AddProductTests(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void AddProduct_CorrectProduct_ReturnsIdProduct()
        {
            var cmd = new AddProductCommand
            {
                Description = "Моё описание",
                Title = "Мой заголовок",
                Price = 12,
                CategoryId = 1,
                VendorId = 1
            };

            var handler = new AddProductCommandHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<int>(result);
            Assert.True(result > 0);
        }
    }
}