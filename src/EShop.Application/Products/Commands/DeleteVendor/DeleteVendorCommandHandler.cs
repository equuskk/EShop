using EShop.DataAccess;
using EShop.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Application.Products.Commands.DeleteVendor
{
    public class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, bool>
    {
        private readonly ProductsDbContext _db;

        public DeleteVendorCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = await _db.Vendors.FirstOrDefaultAsync(x => x.Id == request.Id,
                                                                cancellationToken);

            if (vendor is null)
            {
                throw new NotFoundException(nameof(vendor), request.Id);
            }

            _db.Vendors.Remove(vendor);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
