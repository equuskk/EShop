using System.Threading;
using EShop.Application.Cart.Commands.MakeOrder;
using Xunit;

namespace EShop.Application.Tests.Cart.Commands
{
    public class MakeOrderTests : TestBase
    {
        [Fact]
        public async void MakeOrder_ProductsInCartExists_ReturnsTrue()
        {
            var cmd = new MakeOrderCommand(UserId);
            var handler = new MakeOrderCommandHandler(GetDbContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result);
        }
    }
}