using System.Linq;
using System.Threading;
using EShop.Application.Vendors.Queries.GetAllVendors;
using EShop.DataAccess;
using Xunit;

namespace EShop.Application.Tests.Vendors.Queries
{
    public class GetAllVendorsTests : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public GetAllVendorsTests(ProductsDbContextFixture fixture)
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