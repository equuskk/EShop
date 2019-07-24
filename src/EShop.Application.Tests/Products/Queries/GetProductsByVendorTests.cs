using System.Threading;
using EShop.Application.Products.Queries.GetProductsByVendor;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetProductsByVendorTests : TestBase
    {
        [Fact]
        public async void GetProductsByVendorId_CorrectId_ReturnsProduct()
        {
            var cmd = new GetProductsByVendorQuery
            {
                VendorId = 1
            };
            var handler = new GetProductsByVendorQueryHandler(GetProductsContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotEmpty(result.Products);
        }

        [Fact]
        public async void GetProductsByVendorId_IncorrectId_ReturnsEmptyProducts()
        {
            var cmd = new GetProductsByVendorQuery
            {
                VendorId = 1000
            };
            var handler = new GetProductsByVendorQueryHandler(GetProductsContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.Empty(result.Products);
        }
    }
}