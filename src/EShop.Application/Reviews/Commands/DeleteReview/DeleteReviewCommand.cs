using MediatR;

namespace EShop.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string ShopUserId { get; set; }
    }
}