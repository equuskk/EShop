using System;
using System.Threading;
using EShop.Application.Reviews.Commands.DeleteReview;
using EShop.Domain.Exceptions;
using MediatR;
using Xunit;

namespace EShop.Application.Tests.Reviews.Commands
{
    public class DeleteReviewTests : TestBase
    {
        [Fact]
        public async void DeleteReview_CorrectData_ReturnsUnit()
        {
            var cmd = new DeleteReviewCommand(1, UserId);
            var handler = new DeleteReviewCommandHandler(GetDbContext());

            var result = await handler.Handle(cmd, CancellationToken.None);

            Assert.IsType<Unit>(result);
        }

        [Fact]
        public async void DeleteProduct_IncorrectData_ThrowsException()
        {
            var cmd = new DeleteReviewCommand(-1, UserId);
            var handler = new DeleteReviewCommandHandler(GetDbContext());

            await Assert.ThrowsAsync<NotFoundException>(async () =>
                                                            await handler.Handle(cmd, CancellationToken.None));
        }

        [Fact]
        public async void DeleteProduct_NotSameUserId_ReturnsUnit()
        {
            var cmd = new DeleteReviewCommand(1, Guid.NewGuid().ToString());
            var handler = new DeleteReviewCommandHandler(GetDbContext());

            await Assert.ThrowsAsync<AccessDeniedException>(async () =>
                                                                await handler.Handle(cmd, CancellationToken.None));
        }
    }
}