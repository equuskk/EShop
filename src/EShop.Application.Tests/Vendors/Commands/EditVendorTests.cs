using System.Threading;
using EShop.Application.Vendors.Commands.EditVendor;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Application.Tests.Vendors.Commands
{
    public class EditVendorTests : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public EditVendorTests(ProductsDbContextFixture fixture)
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

            Assert.IsType<Vendor>(result);
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