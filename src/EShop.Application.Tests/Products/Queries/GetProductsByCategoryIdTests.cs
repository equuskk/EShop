using System.Linq;
using System.Threading;
using EShop.Application.Products.Queries.GetProductByCategory;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetProductsByCategoryIdTests : TestBase
    {
        [Fact]
        public async void GetProductsByCategoryId_CorrectId_ReturnsProduct()
        {
            var cmd = new GetProductByCategoryQuery
            {
                CategoryId = 1
            };

            var handler = new GetProductByCategoryQueryHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(result.Products.First().CategoryId, cmd.CategoryId);
        }
    }
}