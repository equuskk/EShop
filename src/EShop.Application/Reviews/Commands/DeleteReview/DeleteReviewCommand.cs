using MediatR;

namespace EShop.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest<Unit>
    {
        public int ReviewId { get; set; }
        public string ShopUserId { get; set; }
    }
}