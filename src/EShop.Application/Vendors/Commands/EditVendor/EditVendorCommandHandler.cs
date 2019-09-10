using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Serilog;

namespace EShop.Application.Vendors.Commands.EditVendor
{
    public class EditVendorCommandHandler : IRequestHandler<EditVendorCommand, Vendor>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public EditVendorCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<EditVendorCommandHandler>();
        }

        public async Task<Vendor> Handle(EditVendorCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug("Редактирование производителя {0}", request.VendorId);
            var vendor = await _db.Vendors.FindAsync(request.VendorId);

            if(vendor is null)
            {
                _logger.Debug("Производитель {0} не найден", request.VendorId);
                throw new NotFoundException(nameof(Vendor), request.VendorId);
            }

            vendor.SetName(request.Name);
            vendor.SetDescription(request.Description);

            await _db.SaveChangesAsync(cancellationToken);
            _logger.Debug("Производитель {0} отредактирован", request.VendorId);

            return vendor;
        }
    }
}