using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;
using Serilog;

namespace EShop.Application.Vendors.Queries.GetVendors
{
    public class GetVendorsQueryHandler : IRequestHandler<GetVendorsQuery, VendorsViewModel>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public GetVendorsQueryHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<GetVendorsQueryHandler>();
        }

        public Task<VendorsViewModel> Handle(GetVendorsQuery request, CancellationToken cancellationToken)
        {
            _logger.Debug("Получение производителей");
            return Task.FromResult(new VendorsViewModel
            {
                Vendors = _db.Vendors.ToArray()
            });
        }
    }
}