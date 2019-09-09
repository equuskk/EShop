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
            var cmd = new AddProductCommand("test", "test", 123, 1, 1, "test/test.png");
            var handler = new AddProductCommandHandler(GetDbContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result > 0);
        }
    }
}