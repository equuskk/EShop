using System;
using System.Threading;
using EShop.Application.Reviews.Commands.DeleteReview;
using EShop.Domain.Exceptions;
using Xunit;

namespace EShop.Application.Tests.Reviews.Commands
{
    public class DeleteReviewTests : TestBase
    {
        [Fact]
        public async void DeleteReview_CorrectData_ReturnsTrue()
        {
            var cmd = new DeleteReviewCommand
            {
                ReviewId = 1,
                ShopUserId = UserId
            };
            var handler = new DeleteReviewCommandHandler(GetProductsContext());
            
            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.True(result);
        }

        [Fact]
        public async void DeleteProduct_IncorrectData_ThrowsException()
        {
            var cmd = new DeleteReviewCommand
            {
                ReviewId = -1,
                ShopUserId = UserId
            };
            var handler = new DeleteReviewCommandHandler(GetProductsContext());

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }

        [Fact]
        public async void DeleteProduct_NotSameUserId_ReturnsFalse()
        {
            var cmd = new DeleteReviewCommand
            {
                ReviewId = 1,
                ShopUserId = Guid.NewGuid().ToString()
            };
            var handler = new DeleteReviewCommandHandler(GetProductsContext());

            var result = await handler.Handle(cmd, CancellationToken.None);
            
            Assert.False(result);
        }
    }
}