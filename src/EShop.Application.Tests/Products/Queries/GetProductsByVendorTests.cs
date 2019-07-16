using System.Linq;
using System.Threading;
using EShop.Application.Products.Queries.GetProductByVendor;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetProductsByVendorTests : TestBase
    {
        [Fact]
        public async void GetProductsByVendorId_CorrectId_ReturnsProduct()
        {
            var cmd = new GetProductByVendorQuery
            {
                VendorId = 1
            };

            var handler = new GetProductByVendorQueryHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(result.Products.First().VendorId, cmd.VendorId);
        }
    }
}