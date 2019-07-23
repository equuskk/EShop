using MediatR;

namespace EShop.Application.Reviews.Queries.GetReviewsByProductId
{
    public class GetReviewsByProductIdQuery : IRequest<ReviewsViewModel>
    {
        public int ProductId { get; set; }
    }
}