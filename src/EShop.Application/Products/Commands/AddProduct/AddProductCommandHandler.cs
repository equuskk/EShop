using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Products.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly ApplicationDbContext _db;

        public AddProductCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price,
                                      request.VendorId, request.CategoryId, request.Image);

            _db.Products.Add(product);
            await _db.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}