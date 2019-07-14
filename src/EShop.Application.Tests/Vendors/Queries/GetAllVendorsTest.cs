using EShop.Application.Vendors.Queries;
using EShop.Application.Vendors.Queries.GetAllVendors;
using EShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Vendors.Queries
{
    public class GetAllVendorsTest : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public GetAllVendorsTest(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void GetAllProducts_Nothing_ProductsNotEmpty()
        {
            var cmd = new GetAllVendorsQuery();

            var handler = new GetAllVendorsQueryHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result.Vendors.Any());
        }
    }
}
