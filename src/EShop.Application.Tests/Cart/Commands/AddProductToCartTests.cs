using System.Threading;
using EShop.Application.Cart.Commands.AddProductToCart;
using MediatR;
using Xunit;

namespace EShop.Application.Tests.Cart.Commands
{
    public class AddProductToCartTests : TestBase
    {
        [Fact]
        public async void AddProductToCart_CartExists_ReturnsUnit()
        {
            var cmd = new AddProductToCartCommand(UserId, 1, 2);
            var handler = new AddProductToCartCommandHandler(GetProductsContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Unit>(result);
        }

        [Fact]
        public async void AddProductToCart_CartDoesNotExists_ReturnsUnit()
        {
            var cmd = new AddProductToCartCommand(UserId, 2, 2);
            var handler = new AddProductToCartCommandHandler(GetProductsContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Unit>(result);
        }
    }
}