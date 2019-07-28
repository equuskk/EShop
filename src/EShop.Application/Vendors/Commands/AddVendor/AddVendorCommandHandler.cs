using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Vendors.Commands.AddVendor
{
    public class AddVendorCommandHandler : IRequestHandler<AddVendorCommand, int>
    {
        private readonly ApplicationDbContext _db;

        public AddVendorCommandHandler(ApplicationDbContext db)
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