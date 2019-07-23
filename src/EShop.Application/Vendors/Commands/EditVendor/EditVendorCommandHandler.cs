using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;

namespace EShop.Application.Vendors.Commands.EditVendor
{
    public class EditVendorCommandHandler : IRequestHandler<EditVendorCommand, Vendor>
    {
        private readonly ProductsDbContext _db;

        public EditVendorCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<Vendor> Handle(EditVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = await _db.Vendors.FindAsync(request.VendorId);

            if(vendor is null)
            {
                throw new NotFoundException(nameof(Vendor), request.VendorId);
            }

            vendor.SetName(request.Name);
            vendor.SetDescription(request.Description);

            await _db.SaveChangesAsync(cancellationToken);

            return vendor;
        }
    }
}