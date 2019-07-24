using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
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
            var product = new Product(request.Title, request.Description, request.Price,
                                      request.VendorId, request.CategoryId);

            _db.Products.Add(product);
            await _db.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}