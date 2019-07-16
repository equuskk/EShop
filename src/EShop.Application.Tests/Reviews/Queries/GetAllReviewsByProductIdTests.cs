using System.Linq;
using System.Threading;
using EShop.Application.Reviews.Queries.GetAllReviewsByProductId;
using Xunit;

namespace EShop.Application.Tests.Reviews.Queries
{
    public class GetAllReviewsByProductIdTests : TestBase
    {
        [Fact]
        public async void GetAllProducts_Nothing_ProductsNotEmpty()
        {
            var cmd = new GetAllReviewsByProductIdQuery { ProductId = 1 };

            var handler = new GetAllReviewsByProductIdQueryHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result.Reviews.Any());
        }
    }
}