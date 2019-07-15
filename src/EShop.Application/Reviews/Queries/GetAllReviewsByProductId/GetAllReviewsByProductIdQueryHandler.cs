using EShop.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Application.Reviews.Queries.GetAllReviewsByProductId
{
    public class GetAllReviewsByProductIdQueryHandler : IRequestHandler<GetAllReviewsByBpoductIdQuery, ReviewsViewModel>
    {

        private readonly ProductsDbContext _db;

        public GetAllReviewsByProductIdQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }
        public async Task<ReviewsViewModel> Handle(GetAllReviewsByBpoductIdQuery request, CancellationToken cancellationToken)
        {
            return new ReviewsViewModel
            {
                Reviews = _db.Reviews.Where(x => x.ProductId == request.ProductId).ToArray()
            };
        }
    }
}
