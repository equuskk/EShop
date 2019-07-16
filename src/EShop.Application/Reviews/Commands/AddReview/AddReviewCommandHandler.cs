using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Reviews.Commands.AddReview
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, int>
    {
        private readonly ProductsDbContext _db;

        public AddReviewCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review(request.Text, request.Rate, request.ShopUserId, request.ProductId);

            _db.Reviews.Add(review);
            await _db.SaveChangesAsync(cancellationToken);

            return review.Id;
        }
    }
}