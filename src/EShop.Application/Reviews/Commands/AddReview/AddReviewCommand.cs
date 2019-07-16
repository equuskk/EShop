using MediatR;

namespace EShop.Application.Reviews.Commands.AddReview
{
    public class AddReviewCommand : IRequest<int>
    {
        public string ShopUserId { get; set; }
        public int ProductId { get; set; }

        public string Text { get; set; }
        public int Rate { get; set; }
    }
}