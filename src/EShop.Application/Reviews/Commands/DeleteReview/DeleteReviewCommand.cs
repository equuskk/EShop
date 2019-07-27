using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest<Unit>
    {
        public int ReviewId { get; }
        public string ShopUserId { get; }

        [JsonConstructor]
        public DeleteReviewCommand(int reviewId, string shopUserId)
        {
            ReviewId = reviewId;
            ShopUserId = shopUserId;
        }
    }
}