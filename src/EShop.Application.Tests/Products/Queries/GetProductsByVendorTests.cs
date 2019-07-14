using System.Linq;
using System.Threading;
using EShop.Application.Products.Queries.GetProductByVendor;
using EShop.DataAccess;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetProductsByVendorTests : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public GetProductsByVendorTests(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void GetProductsByVendorId_CorrectId_ReturnsProduct()
        {
            var cmd = new GetProductByVendorQuery
            {
                VendorId = 1
            };

            var handler = new GetProductByVendorQueryHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(result.Products.First().VendorId, cmd.VendorId);
        }
    }
}