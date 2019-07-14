using EShop.Application.Products.Queries.GetAllProducts;
using EShop.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Application.Vendors.Queries.GetAllVendors
{

    public class GetAllVendorsQueryHandler : IRequestHandler<GetAllVendorsQuery, VendorsViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetAllVendorsQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<VendorsViewModel> Handle(GetAllVendorsQuery request, CancellationToken cancellationToken)
        {
            return new VendorsViewModel
            {
                Vendors = _db.Vendors.ToArray()
            };
        }
    }
}
