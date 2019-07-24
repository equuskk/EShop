using System.Threading;
using EShop.Application.Vendors.Queries.GetVendors;
using Xunit;

namespace EShop.Application.Tests.Vendors.Queries
{
    public class GetVendorsTests : TestBase
    {
        [Fact]
        public async void GetVendors_Nothing_VendorsNotEmpty()
        {
            var cmd = new GetVendorsQuery();
            var handler = new GetVendorsQueryHandler(GetProductsContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotEmpty(result.Vendors);
        }
    }
}