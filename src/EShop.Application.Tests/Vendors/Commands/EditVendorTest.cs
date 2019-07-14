using EShop.Application.Vendors.Commands.EditVendor;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Vendors.Commands
{
    public class EditVendorTest : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public EditVendorTest(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void EditCategory_CorrectData_ReturnsCategory()
        {
            var cmd = new EditVendorCommand
            {
                Id = 1,
                Name = "New Name",
                Description = "New Description"    
            };

            var handler = new EditVendorCommandHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<EShop.Domain.Entities.Vendor>(result);
            Assert.Equal(cmd.Id, result.Id);
            Assert.Equal(cmd.Name, result.Name);
        }

        [Fact]
        public async void EditCategory_IncorrectData_ThrowsException()
        {
            var cmd = new EditVendorCommand
            {
                Id = -1,
                Name = "Test"
            };

            var handler = new EditVendorCommandHandler(context);
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}
