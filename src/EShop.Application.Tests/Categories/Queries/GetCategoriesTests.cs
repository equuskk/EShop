using System.Linq;
using System.Threading;
using EShop.Application.Categories.Queries.GetCategories;
using Xunit;

namespace EShop.Application.Tests.Categories.Queries
{
    public class GetCategoriesTests : TestBase
    {
        [Fact]
        public async void GetCategories_Nothing_CategoriesNotEmpty()
        {
            var cmd = new GetCategoriesQuery();
            var handler = new GetCategoriesQueryHandler(GetProductsContext());
            
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotEmpty(result.Categories);
        }
    }
}