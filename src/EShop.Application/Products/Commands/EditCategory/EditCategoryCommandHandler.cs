using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Application.Products.Commands.EditCategory
{
    class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, Category>
    {
        private readonly ProductsDbContext _db;

        public EditCategoryCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public  async Task<Category> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == request.Id,
                                                                cancellationToken);

            if (category is null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            category.SetName(request.Name);
            await _db.SaveChangesAsync(cancellationToken);

            return category;
        }
    }
}
