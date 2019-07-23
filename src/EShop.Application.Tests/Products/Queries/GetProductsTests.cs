using System.Linq;
using System.Threading;
using EShop.Application.Products.Queries.GetProducts;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetProductsTests : TestBase
    {
        [Fact]
        public async void GetAllProducts_Nothing_ProductsNotEmpty()
        {
            var cmd = new GetProductsQuery();

            var handler = new GetProductsQueryHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotEmpty(result.Products);
        }
    }
}