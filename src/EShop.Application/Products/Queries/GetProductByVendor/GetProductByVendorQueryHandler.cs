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

namespace EShop.Application.Products.Queries.GetProductByVendor
{
    public class GetProductByVendorQueryHandler : IRequestHandler<GetProductByVendorQuery, ProductsViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetProductByVendorQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<ProductsViewModel> Handle(GetProductByVendorQuery request, CancellationToken cancellationToken)
        {
            var vendor = await _db.Vendors.FirstOrDefaultAsync(x => x.Id == request.VendorId);

            if (vendor is null)
            {
                throw new NotFoundException(nameof(vendor), request.VendorId);
            }

            return new ProductsViewModel
            {
                Products = _db.Products.Include(x => x.Vendor).Where(x => x.VendorId == vendor.Id).ToArray()
            };

        }
    }
}
