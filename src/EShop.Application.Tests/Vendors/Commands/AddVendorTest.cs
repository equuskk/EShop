using EShop.Application.Vendors.Commands.AddVendor;
using EShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Vendors.Commands
{
    public class AddVendorTest : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public AddVendorTest(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void AddVendor_CorrectVendor_ReturnsIdVendor()
        {
            var cmd = new AddVendorCommand
            {
                Name = "Тест"
            };

            var handler = new AddVendorCommandHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<int>(result);
            Assert.True(result > 0);
        }
    }
}
