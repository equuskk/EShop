using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Serilog;

namespace EShop.Application.Vendors.Commands.DeleteVendor
{
    public class DeleteVendorCommandHandler : IRequestHandler<DeleteVendorCommand, Unit>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public DeleteVendorCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<DeleteVendorCommandHandler>();
        }

        public async Task<Unit> Handle(DeleteVendorCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug("Удаление производителя {0}", request.VendorId);
            var vendor = await _db.Vendors.FindAsync(request.VendorId);

            if(vendor is null)
            {
                _logger.Debug("Производитель {0} не найден", request.VendorId);
                throw new NotFoundException(nameof(Vendor), request.VendorId);
            }

            _db.Vendors.Remove(vendor);
            await _db.SaveChangesAsync(cancellationToken);
            _logger.Debug("Производитель {0} удалён", request.VendorId);

            return Unit.Value;
        }
    }
}