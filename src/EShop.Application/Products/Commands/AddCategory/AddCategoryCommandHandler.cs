using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Application.Products.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, int>
    {
        private readonly ProductsDbContext _db;

        public AddCategoryCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }
        public async Task<int> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Name);

            _db.Categories.Add(category);

            await _db.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
    }
}
