using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Reviews.Queries.GetReviewsByProductId
{
    public class GetReviewsByProductIdQuery : IRequest<ReviewsViewModel>
    {
        public int ProductId { get; }

        [JsonConstructor]
        public GetReviewsByProductIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}