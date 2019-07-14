using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Vendors.Queries.GetAllVendors
{
    public class GetAllVendorsQueryHandler : IRequestHandler<GetAllVendorsQuery, VendorsViewModel>
    {
        private readonly ProductsDbContext _db;

        public GetAllVendorsQueryHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<VendorsViewModel> Handle(GetAllVendorsQuery request, CancellationToken cancellationToken)
        {
            return new VendorsViewModel
            {
                Vendors = _db.Vendors.ToArray()
            };
        }
    }
}