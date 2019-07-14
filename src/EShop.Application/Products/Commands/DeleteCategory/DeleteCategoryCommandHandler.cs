using EShop.DataAccess;
using EShop.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Application.Products.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ProductsDbContext _db;

        public DeleteCategoryCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == request.Id,
                                                                cancellationToken);

            if (category is null)
            {
                throw new NotFoundException(nameof(category), request.Id);
            }

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
