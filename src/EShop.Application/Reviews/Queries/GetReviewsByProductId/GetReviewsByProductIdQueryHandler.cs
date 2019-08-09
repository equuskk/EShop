using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Reviews.Queries.GetReviewsByProductId
{
    public class GetReviewsByProductIdQueryHandler : IRequestHandler<GetReviewsByProductIdQuery, ReviewsViewModel>
    {
        private readonly ApplicationDbContext _db;

        public GetReviewsByProductIdQueryHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<ReviewsViewModel> Handle(GetReviewsByProductIdQuery request,
                                             CancellationToken cancellationToken)
        {
            return Task.FromResult(new ReviewsViewModel
            {
                Reviews = _db.Reviews.Include(x => x.User).Where(x => x.ProductId == request.ProductId).ToArray()
            });
        }
    }
}