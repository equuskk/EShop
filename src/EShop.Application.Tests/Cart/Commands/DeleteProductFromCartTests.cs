using System.Threading;
using EShop.Application.Cart.Commands.DeleteProductFromCart;
using EShop.Domain.Exceptions;
using MediatR;
using Xunit;

namespace EShop.Application.Tests.Cart.Commands
{
    public class DeleteProductFromCartTests : TestBase
    {
        [Fact]
        public async void DeleteProductFromCart_CorrectData_ReturnsUnit()
        {
            var cmd = new DeleteProductFromCartCommand(1, 1, UserId);
            var handler = new DeleteProductFromCartCommandHandler(GetDbContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Unit>(result);
        }

        [Fact]
        public async void DeleteProductFromCart_IncorrectProductId_ThrowsException()
        {
            var cmd = new DeleteProductFromCartCommand(-1, 123, UserId);
            var handler = new DeleteProductFromCartCommandHandler(GetDbContext());

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}