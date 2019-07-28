using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;

namespace EShop.Application.Vendors.Commands.DeleteVendor
{
    public class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, Unit>
    {
        private readonly ApplicationDbContext _db;

        public DeleteVendorCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
        {
            var vendor = await _db.Vendors.FindAsync(request.VendorId);

            if(vendor is null)
            {
                throw new NotFoundException(nameof(Vendor), request.VendorId);
            }

            _db.Vendors.Remove(vendor);
            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}