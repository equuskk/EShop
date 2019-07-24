using System.Threading;
using EShop.Application.Cart.Commands.AddProductToCart;
using MediatR;
using Xunit;

namespace EShop.Application.Tests.Cart.Commands
{
    public class AddProductToCartTests : TestBase
    {
        [Fact]
        public async void AddProductInCart_CartExists_ReturnsUnit()
        {
            var cmd = new AddProductToCartCommand
            {
                ProductId = 1,
                Quantity = 2,
                ShopUserId = UserId
            };
            var handler = new AddProductToCartCommandHandler(GetProductsContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Unit>(result);
        }

        [Fact]
        public async void AddProductInCart_CartDoesNotExists_ReturnsUnit()
        {
            var cmd = new AddProductToCartCommand
            {
                ProductId = 2,
                Quantity = 2,
                ShopUserId = UserId
            };
            var handler = new AddProductToCartCommandHandler(GetProductsContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Unit>(result);
        }
    }
}