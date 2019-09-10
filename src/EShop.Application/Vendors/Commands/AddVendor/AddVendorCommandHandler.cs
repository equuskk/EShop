using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;
using Serilog;

namespace EShop.Application.Vendors.Commands.AddVendor
{
    public class AddVendorCommandHandler : IRequestHandler<AddVendorCommand, int>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public AddVendorCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<AddVendorCommandHandler>();
        }

        public async Task<int> Handle(AddVendorCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug("Добавление производителя");
            var vendor = new Vendor(request.Name, request.Description);

            _db.Vendors.Add(vendor);

            await _db.SaveChangesAsync(cancellationToken);
            _logger.Debug("Добавлен производитель {0}", vendor.Id);
            
            return vendor.Id;
        }
    }
}