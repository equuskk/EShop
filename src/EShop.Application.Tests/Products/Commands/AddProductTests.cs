using System.Threading;
using EShop.Application.Products.Commands.CreateNewProduct;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class AddProductTests : TestBase
    {
        [Fact]
        public async void CreateNewProduct_CorrectProduct_ReturnsProduct()
        {
            var cmd = new AddProductCommand
            {
                Id = 3,
                Description = "Моё описание",
                Title = "Мой заголовок",
                Price = 12
            };

            var handler = new AddProductCommandHandler(GetDbContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(cmd.Price, result.Price);
            Assert.Equal(cmd.Title, result.Title);
        }
    }
}