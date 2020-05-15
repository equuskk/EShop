using System.Threading;
using EShop.Application.Products.Queries.GetProductById;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Application.Tests.Products.Queries
{
    public class GetProductByIdTests : TestBase
    {
        [Fact]
        public async void GetProductById_CorrectId_ReturnsProduct()
        {
            var cmd = new GetProductByIdQuery(1);
            var handler = new GetProductByIdQueryHandler(GetDbContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(cmd.ProductId, result.Id);
        }

        [Fact]
        public async void GetProductById_IncorrectId_ThrowsException()
        {
            var cmd = new GetProductByIdQuery(-1);
            var handler = new GetProductByIdQueryHandler(GetDbContext());

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}