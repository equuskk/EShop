using System.Threading;
using EShop.Application.Products.Queries.GetProductsByCategory;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetProductsByCategoryIdTests : TestBase
    {
        [Fact]
        public async void GetProductsByCategoryId_CorrectId_ReturnsProduct()
        {
            var cmd = new GetProductsByCategoryQuery(1);
            var handler = new GetProductsByCategoryQueryHandler(GetDbContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotEmpty(result.Products);
        }

        [Fact]
        public async void GetProductsByCategoryId_IncorrectId_ReturnsProduct()
        {
            var cmd = new GetProductsByCategoryQuery(1000);
            var handler = new GetProductsByCategoryQueryHandler(GetDbContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.Empty(result.Products);
        }
    }
}