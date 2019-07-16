using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using EShop.Application.Reviews.Queries.GetAllReviewsByProductId;
using System.Threading;
using System.Linq;

namespace EShop.Application.Tests.Reviews.Queries
{
    public class GetAllReviewsByProductIdTest : TestBase
    {
        [Fact]
        public async void GetAllProducts_Nothing_ProductsNotEmpty()
        {
            var cmd = new GetAllReviewsByProductIdQuery { ProductId = 1};

            var handler = new GetAllReviewsByProductIdQueryHandler(GetProductsContext());
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result.Reviews.Any());
        }
    }
}
