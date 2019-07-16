using System.Linq;
using System.Threading;
using EShop.Application.Vendors.Queries.GetAllVendors;
using Xunit;

namespace EShop.Application.Tests.Vendors.Queries
{
    public class GetAllVendorsTests : TestBase
    {
        [Fact]
        public async void GetAllProducts_Nothing_ProductsNotEmpty()
        {
            var cmd = new GetAllVendorsQuery();

            var handler = new GetAllVendorsQueryHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result.Vendors.Any());
        }
    }
}