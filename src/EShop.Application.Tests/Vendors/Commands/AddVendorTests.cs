using System.Threading;
using EShop.Application.Vendors.Commands.AddVendor;
using Xunit;

namespace EShop.Application.Tests.Vendors.Commands
{
    public class AddVendorTests : TestBase
    {
        [Fact]
        public async void AddVendor_CorrectData_ReturnsIdVendor()
        {
            var cmd = new AddVendorCommand
            {
                Name = "test",
                Description = "test"
            };

            var handler = new AddVendorCommandHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result > 0);
        }
    }
}