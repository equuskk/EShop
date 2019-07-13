using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Products.Commands.EditProduct
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, Product>
    {
        private readonly ProductsDbContext _db;

        public EditProductCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<Product> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == request.Id,
                                                                 cancellationToken);

            if(product is null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            product.Price = request.Price;
            product.Title = request.Title;
            product.Description = request.Description; //TODO: automapper

            await _db.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}