﻿using System.Threading;
using EShop.Application.Vendors.Commands.AddVendor;
using Xunit;

namespace EShop.Application.Tests.Vendors.Commands
{
    public class AddVendorTests : TestBase
    {
        [Fact]
        public async void AddVendor_CorrectData_ReturnsVendorId()
        {
            var cmd = new AddVendorCommand("test", "test");
            var handler = new AddVendorCommandHandler(GetDbContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result > 0);
        }
    }
}