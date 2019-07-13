using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Application.Products.Commands.AddVendor
{
    public class AddVendorCommandHandler : IRequestHandler<AddVendorCommand, int>
    {
        private readonly ProductsDbContext _db;

        public AddVendorCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(AddVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = new Vendor(request.Name, request.Description);

            _db.Vendors.Add(vendor);

            await _db.SaveChangesAsync(cancellationToken);

            return vendor.Id;
        }
    }
}
