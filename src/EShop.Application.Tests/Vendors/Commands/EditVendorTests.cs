using System.Threading;
using EShop.Application.Vendors.Commands.EditVendor;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Application.Tests.Vendors.Commands
{
    public class EditVendorTests : TestBase
    {
        [Fact]
        public async void EditCategory_CorrectData_ReturnsCategory()
        {
            var cmd = new EditVendorCommand
            {
                VendorId = 1,
                Name = "New Name",
                Description = "New Description"
            };

            var handler = new EditVendorCommandHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Vendor>(result);
            Assert.Equal(cmd.VendorId, result.Id);
            Assert.Equal(cmd.Name, result.Name);
        }

        [Fact]
        public async void EditCategory_IncorrectData_ThrowsException()
        {
            var cmd = new EditVendorCommand
            {
                VendorId = -1,
                Name = "Test"
            };

            var handler = new EditVendorCommandHandler(GetProductsContext());
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}