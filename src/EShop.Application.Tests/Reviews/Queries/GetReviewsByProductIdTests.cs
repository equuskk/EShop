using System.Linq;
using System.Threading;
using EShop.Application.Reviews.Queries.GetReviewsByProductId;
using Xunit;

namespace EShop.Application.Tests.Reviews.Queries
{
    public class GetReviewsByProductIdTests : TestBase
    {
        [Fact]
        public async void GetReviews_CorrectProductId_ReviewsNotEmpty()
        {
            var cmd = new GetReviewsByProductIdQuery { ProductId = 1 };

            var handler = new GetReviewsByProductIdQueryHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotEmpty(result.Reviews);
        }
    }
}