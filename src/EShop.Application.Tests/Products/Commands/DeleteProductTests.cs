﻿using System.Threading;
using EShop.Application.Products.Commands.DeleteProduct;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class DeleteProductTests : TestBase
    {
        [Fact]
        public async void DeleteProduct_CorrectData_ReturnsTrue()
        {
            var cmd = new DeleteProductCommand
            {
                Id = 100
            };

            var handler = new DeleteProductCommandHandler(GetDbContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public async void DeleteProduct_IncorrectData_ThrowsException()
        {
            var cmd = new DeleteProductCommand
            {
                Id = 1
            };

            var handler = new DeleteProductCommandHandler(GetDbContext());
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}