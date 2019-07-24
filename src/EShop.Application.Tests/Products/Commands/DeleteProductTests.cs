using System.Threading;
using EShop.Application.Products.Commands.DeleteProduct;
using EShop.Domain.Exceptions;
using MediatR;
using Xunit;

namespace EShop.Application.Tests.Products.Commands
{
    public class DeleteProductTests : TestBase
    {
        [Fact]
        public async void DeleteProduct_CorrectProductId_ReturnsUnit()
        {
            var cmd = new DeleteProductCommand
            {
                ProductId = 1
            };
            var handler = new DeleteProductCommandHandler(GetProductsContext());
            
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Unit>(result);
        }

        [Fact]
        public async void DeleteProduct_IncorrectProductId_ThrowsException()
        {
            var cmd = new DeleteProductCommand
            {
                ProductId = -1
            };
            var handler = new DeleteProductCommandHandler(GetProductsContext());
            
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }
    }
}