using System.Linq;
using System.Threading;
using EShop.Application.Categories.Queries.GetAllCategories;
using Xunit;

namespace EShop.Application.Tests.Categories.Queries
{
    public class GetAllCategoriesTests : TestBase
    {
        [Fact]
        public async void GetAllProducts_Nothing_ProductsNotEmpty()
        {
            var cmd = new GetAllCategoriesQuery();

            var handler = new GetAllCategoriesQueryHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result.Categories.Any());
        }
    }
}