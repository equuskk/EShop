using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;

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
            var product = await _db.Products.FindAsync(request.ProductId);

            if(product is null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            product.SetPrice(request.Price);
            product.SetTitle(request.Name);
            product.SetDescription(request.Description);
            product.SetVendorId(request.VendorId);
            product.SetCategoryId(request.CategoryId);

            await _db.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}