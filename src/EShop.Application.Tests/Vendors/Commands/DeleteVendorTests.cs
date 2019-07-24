﻿using System.Threading;
using EShop.Application.Vendors.Commands.DeleteVendor;
using EShop.Domain.Exceptions;
using MediatR;
using Xunit;

namespace EShop.Application.Tests.Vendors.Commands
{
    public class DeleteVendorTests : TestBase
    {
        [Fact]
        public async void DeleteCategory_CorrectVendorId_ReturnsTrue()
        {
            var cmd = new DeleteVendorCommand
            {
                VendorId = 1
            };
            var handler = new DeleteVendorCommandHandler(GetProductsContext());
            
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Unit>(result);
        }

        [Fact]
        public async void DeleteCategory_IncorrectVendorId_ThrowsException()
        {
            var cmd = new DeleteVendorCommand
            {
                VendorId = -1
            };
            var handler = new DeleteVendorCommandHandler(GetProductsContext());
            
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}