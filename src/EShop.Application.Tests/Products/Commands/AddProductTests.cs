using System.Threading;
using EShop.Application.Products.Commands.AddProduct;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class AddProductTests : TestBase
    {
        [Fact]
        public async void AddProduct_CorrectData_ReturnsProductId()
        {
            var cmd = new AddProductCommand("test", "test", 123, 1, 1);
            var handler = new AddProductCommandHandler(GetProductsContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result > 0);
        }
    }
}