using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using MediatR;

namespace EShop.Application.Vendors.Commands.DeleteVendor
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
            var vendor = await _db.Vendors.FindAsync(request.Id);

            if(vendor is null)
            {
                throw new NotFoundException(nameof(vendor), request.Id);
            }

            _db.Vendors.Remove(vendor);
            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}