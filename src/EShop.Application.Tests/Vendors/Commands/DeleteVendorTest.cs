using EShop.Application.Vendors.Commands.DeleteVendor;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Vendors.Commands
{
    public class DeleteVendorTest : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public DeleteVendorTest(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void DeleteCategory_CorrectData_ReturnsTrue()
        {
            var cmd = new DeleteVendorCommand
            {
                Id = 1
            };

            var handler = new DeleteVendorCommandHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public async void DeleteCategory_IncorrectData_ThrowsException()
        {
            var cmd = new DeleteVendorCommand
            {
                Id = -1
            };

            var handler = new DeleteVendorCommandHandler(context);
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}
