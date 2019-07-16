using MediatR;

namespace EShop.Application.Reviews.Queries.GetAllReviewsByProductId
{
    public class GetAllReviewsByProductIdQuery : IRequest<ReviewsViewModel>
    {
        public int ProductId { get; set; }
    }
}