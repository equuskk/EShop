using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;
using Serilog;

namespace EShop.Application.Reviews.Commands.AddReview
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, int>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;
        public AddReviewCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<AddReviewCommandHandler>();
        }

        public async Task<int> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review(request.Text, request.Rate, request.ShopUserId, request.ProductId);

            _logger.Debug("Добавление отзыва");
            _db.Reviews.Add(review);
            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Отзыв добавлен, ID отзыва:{0}",review.Id);

            return review.Id;
        }
    }
}