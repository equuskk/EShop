using EShop.Application.Products.Queries.GetAllProducts;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Application.Products.Queries.GetProductByCategory
{
    public class GetProductByCategoryQueryHandler : IRequestHandler<GetProductByCategoryQuery, ProductsViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetProductByCategoryQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<ProductsViewModel> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == request.CategooryId);

            if (category is null)
            {
                throw new NotFoundException(nameof(category), request.CategooryId);
            }

            return new ProductsViewModel
            {
                Products = _db.Products.Include(x => x.Category).Where(x => x.CategoryId == category.Id).ToArray()
            };

        }
    }
}
