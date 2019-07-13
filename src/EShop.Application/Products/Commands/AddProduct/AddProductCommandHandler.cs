using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;

namespace EShop.Application.Products.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly ProductsDbContext _db;

        public AddProductCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var vendor = _db.Vendors.Find(request.VendorId);
            if(vendor is null)
            {
                throw new NotFoundException(nameof(vendor), request.VendorId);
            }

            var category = _db.Categories.Find(request.CategoryId);
            if(category is null)
            {
                throw new NotFoundException(nameof(category), request.CategoryId);
            }

            var product = new Product(request.Title, request.Description, request.Price,
                                      request.VendorId, request.CategoryId);

            _db.Products.Add(product);
            await _db.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}