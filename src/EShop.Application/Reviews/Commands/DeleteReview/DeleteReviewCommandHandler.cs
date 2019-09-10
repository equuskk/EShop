using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EShop.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Unit>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;
        public DeleteReviewCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<DeleteReviewCommandHandler>();
        }

        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug("Удаление отзыва с ID: {0}", request.ReviewId);
            var review = await _db.Reviews.FirstOrDefaultAsync(x => x.Id == request.ReviewId,
                                                               cancellationToken);

            if(review is null)
            {
                _logger.Debug("Отзыв с ID: {0} не найден", request.ReviewId);
                throw new NotFoundException(nameof(Review), request.ReviewId);
            }

            if(request.ShopUserId != review.UserId)
            {
                throw new AccessDeniedException();
            }

            _db.Reviews.Remove(review);
            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Отзыв с ID: {0} удалён", request.ReviewId);

            return Unit.Value;
        }
    }
}