using System.Linq;
using System.Threading;
using EShop.Application.Products.Queries.GetAllProducts;
using EShop.DataAccess;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetAllProductsTests : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public GetAllProductsTests(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void GetAllProducts_Nothing_ProductsNotEmpty()
        {
            var cmd = new GetAllProductsQuery();

            var handler = new GetAllProductsQueryHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result.Products.Any());
        }
    }
}