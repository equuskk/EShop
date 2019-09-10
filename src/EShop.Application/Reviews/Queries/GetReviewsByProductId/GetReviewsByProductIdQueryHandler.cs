using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EShop.Application.Reviews.Queries.GetReviewsByProductId
{
    public class GetReviewsByProductIdQueryHandler : IRequestHandler<GetReviewsByProductIdQuery, ReviewsViewModel>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public GetReviewsByProductIdQueryHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<GetReviewsByProductIdQueryHandler>();
        }

        public Task<ReviewsViewModel> Handle(GetReviewsByProductIdQuery request,
                                             CancellationToken cancellationToken)
        {
            _logger.Debug("Получение отзывов у продукта {0}", request.ProductId);

            return Task.FromResult(new ReviewsViewModel
            {
                Reviews = _db.Reviews.Include(x => x.User).Where(x => x.ProductId == request.ProductId).ToArray()
            });
        }
    }
}