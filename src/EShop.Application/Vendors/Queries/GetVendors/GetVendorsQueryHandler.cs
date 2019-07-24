using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Vendors.Queries.GetVendors
{
    public class GetVendorsQueryHandler : IRequestHandler<GetVendorsQuery, VendorsViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetVendorsQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public Task<VendorsViewModel> Handle(GetVendorsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new VendorsViewModel
            {
                Vendors = _db.Vendors.ToArray()
            });
        }
    }
}