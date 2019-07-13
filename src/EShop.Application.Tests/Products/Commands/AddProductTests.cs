using System.Threading;
using EShop.Application.Products.Commands.AddProduct;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class AddProductTests : TestBase
    {
        [Fact]
        public async void AddProduct_CorrectProduct_ReturnsProduct()
        {
            var cmd = new AddProductCommand
            {
                Description = "Моё описание",
                Title = "Мой заголовок",
                Price = 12
            };

            var handler = new AddProductCommandHandler(GetDbContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<int>(result);
            Assert.True(result > 0);
        }
    }
}