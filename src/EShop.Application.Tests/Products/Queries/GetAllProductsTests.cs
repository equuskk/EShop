using System.Linq;
using System.Threading;
using EShop.Application.Products.Queries;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetAllProductsTests : TestBase
    {
        [Fact]
        public async void GetAllProducts_Nothing_ProductsNotEmpty()
        {
            var cmd = new GetAllProductsQuery();

            var handler = new GetAllProductsQueryHandler(GetDbContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result.Products.Any());
            Assert.True(result.Products.Length == 2);
        }
    }
}