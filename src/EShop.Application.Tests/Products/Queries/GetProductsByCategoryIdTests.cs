using System.Linq;
using System.Threading;
using EShop.Application.Products.Queries.GetProductByCategory;
using EShop.DataAccess;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetProductsByCategoryIdTests : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public GetProductsByCategoryIdTests(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void GetProductsByCategoryId_CorrectId_ReturnsProduct()
        {
            var cmd = new GetProductByCategoryQuery
            {
                CategoryId = 1
            };

            var handler = new GetProductByCategoryQueryHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(result.Products.First().CategoryId, cmd.CategoryId);
        }
    }
}