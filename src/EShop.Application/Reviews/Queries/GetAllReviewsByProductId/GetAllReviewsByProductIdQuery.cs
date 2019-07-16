using MediatR;

namespace EShop.Application.Reviews.Queries.GetAllReviewsByProductId
{
    public class GetReviewsByProductIdQuery : IRequest<ReviewsViewModel>
    {
        public int ProductId { get; set; }
    }
}