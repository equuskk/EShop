using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Reviews.Queries.GetAllReviewsByProductId
{
    public class GetAllReviewsByProductIdQueryHandler : IRequestHandler<GetReviewsByProductIdQuery, ReviewsViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetAllReviewsByProductIdQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<ReviewsViewModel> Handle(GetReviewsByProductIdQuery request,
                                                   CancellationToken cancellationToken)
        {
            return new ReviewsViewModel
            {
                Reviews = _db.Reviews.Where(x => x.ProductId == request.ProductId).ToArray()
            };
        }
    }
}