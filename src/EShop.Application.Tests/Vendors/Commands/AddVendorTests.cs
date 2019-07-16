using System.Threading;
using EShop.Application.Vendors.Commands.AddVendor;
using Xunit;

namespace EShop.Application.Tests.Vendors.Commands
{
    public class AddVendorTests : TestBase
    {
        [Fact]
        public async void AddVendor_CorrectVendor_ReturnsIdVendor()
        {
            var cmd = new AddVendorCommand
            {
                Name = "Тест",
                Description = "Описание"
            };

            var handler = new AddVendorCommandHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<int>(result);
            Assert.True(result > 0);
        }
    }
}