using EShop.Application.Products.Queries.GetAllProducts;
using EShop.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Application.Products.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, CategoriesViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetAllCategoriesQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }
        public async Task<CategoriesViewModel> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return new CategoriesViewModel
            {
                Categories = _db.Categories.ToArray()
            };
        }
    }
}
