using EShop.Application.Products.Commands.DeleteProductFromCart;
using EShop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class DeleteProductFromCartTest : TestBase
    {
        [Fact]
        public async void DeleteProduct_CorrectData_ReturnsTrue()
        {
            var cmd = new DeleteProductFromCartCommand
            {
                ProductId = 1,
                ShopUserId = UserId,
                Quantity = 1
            };

            var handler = new DeleteProductFromCartCommandHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public async void DeleteProduct_IncorrectData_ThrowsException()
        {
            var cmd = new DeleteProductFromCartCommand
            {
               ProductId = -1
            };

            var handler = new DeleteProductFromCartCommandHandler(GetProductsContext());
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}
