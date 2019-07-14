using System.Linq;
using System.Threading;
using EShop.Application.Categories.Queries.GetAllCategories;
using EShop.DataAccess;
using Xunit;

namespace EShop.Application.Tests.Categories.Queries
{
    public class GetAllCategoriesTests : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public GetAllCategoriesTests(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void GetAllProducts_Nothing_ProductsNotEmpty()
        {
            var cmd = new GetAllCategoriesQuery();

            var handler = new GetAllCategoriesQueryHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result.Categories.Any());
        }
    }
}