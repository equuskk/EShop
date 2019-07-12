using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Products.Commands.CreateNewProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly ProductsDbContext _db;

        public AddProductCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var pr = new Product
            {
                Id = request.Id,
                Description = request.Description,
                Price = request.Price,
                Title = request.Title
            };

            _db.Products.Add(pr);
            await _db.SaveChangesAsync();

            return pr;
        }
    }
}