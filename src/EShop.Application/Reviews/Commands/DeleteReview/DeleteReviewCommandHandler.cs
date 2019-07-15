using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Application.Reviews.Commands.DeleteReview
{
    class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, bool>
    {
        private readonly ProductsDbContext _db;

        public DeleteReviewCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _db.Reviews.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (review is null)
            {
                throw new NotFoundException(nameof(Review), request.Id);
            }

            if (request.ShopUserId != review.ShopUserId)
            {
                return false;
            }

            _db.Reviews.Remove(review);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
