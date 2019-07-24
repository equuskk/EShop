using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Reviews.Queries.GetReviewsByProductId
{
    public class GetReviewsByProductIdQueryHandler : IRequestHandler<GetReviewsByProductIdQuery, ReviewsViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetReviewsByProductIdQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public Task<ReviewsViewModel> Handle(GetReviewsByProductIdQuery request,
                                                   CancellationToken cancellationToken)
        {
            return Task.FromResult(new ReviewsViewModel
            {
                Reviews = _db.Reviews.Where(x => x.ProductId == request.ProductId).ToArray()
            });
        }
    }
}