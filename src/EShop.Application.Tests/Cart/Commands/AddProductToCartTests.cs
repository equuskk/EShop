using System.Threading;
using EShop.Application.Cart.Commands.AddProductToCart;
using Xunit;

namespace EShop.Application.Tests.Cart.Commands
{
    public class AddProductToCartTests : TestBase
    {
        [Fact]
        public async void AddProductInCart_CorrectData_ReturnsIdProductInCart()
        {
            var cmd = new AddProductToCartCommand
            {
                ProductId = 1,
                Quantity = 2,
                ShopUserId = UserId
            };

            var handler = new AddProductToCartCommandHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result);
        }
    }
}