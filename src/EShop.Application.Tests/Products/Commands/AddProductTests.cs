using System.Threading;
using EShop.Application.Products.Commands.AddProduct;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class AddProductTests : TestBase
    {
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

            var handler = new AddProductCommandHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<int>(result);
            Assert.True(result > 0);
        }
    }
}