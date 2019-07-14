using EShop.Application.Products.Queries.GetProductByCategory;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetProductByCategoryTest : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public GetProductByCategoryTest(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void GetProductById_CorrectId_ReturnsProduct()
        {
            var cmd = new GetProductByCategoryQuery
            {
                CategooryId = 1
            };

            var handler = new GetProductByCategoryQueryHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(result.Products.First().CategoryId, cmd.CategooryId);
        }

        [Fact]
        public async void GetProductById_IncorrectId_ThrowsException()
        {
            var cmd = new GetProductByCategoryQuery
            {
                CategooryId = -1
            };

            var handler = new GetProductByCategoryQueryHandler(context);
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}
