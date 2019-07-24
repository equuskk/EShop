﻿using System.Threading;
using EShop.Application.Cart.Commands.DeleteProductFromCart;
using EShop.Domain.Exceptions;
using MediatR;
using Xunit;

namespace EShop.Application.Tests.Cart.Commands
{
    public class DeleteProductFromCartTests : TestBase
    {
        [Fact]
        public async void DeleteProduct_CorrectData_ReturnsUnit()
        {
            var cmd = new DeleteProductFromCartCommand
            {
                ProductId = 1,
                ShopUserId = UserId,
                Quantity = 1
            };
            var handler = new DeleteProductFromCartCommandHandler(GetProductsContext());
            
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Unit>(result);
        }

        [Fact]
        public async void DeleteProduct_IncorrectProductId_ThrowsException()
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