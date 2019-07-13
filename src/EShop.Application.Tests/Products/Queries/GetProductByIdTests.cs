using System.Threading;
using EShop.Application.Products.Queries.GetProductById;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetProductByIdTests : IClassFixture<ProductsDbContextFixture>
    {
        private readonly ProductsDbContext context;

        public GetProductByIdTests(ProductsDbContextFixture fixture)
        {
            context = fixture.Context;
        }

        [Fact]
        public async void GetProductById_CorrectId_ReturnsProduct()
        {
            var cmd = new GetProductByIdQuery
            {
                Id = 2
            };

            var handler = new GetProductByIdQueryHandler(context);
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(cmd.Id, result.Id);
        }

        [Fact]
        public async void GetProductById_IncorrectId_ThrowsException()
        {
            var cmd = new GetProductByIdQuery
            {
                Id = 0
            };

            var handler = new GetProductByIdQueryHandler(context);
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}