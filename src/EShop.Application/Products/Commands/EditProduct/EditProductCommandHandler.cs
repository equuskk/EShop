using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Serilog;

namespace EShop.Application.Products.Commands.EditProduct
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, Product>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;
        public EditProductCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<EditProductCommandHandler>();
        }

        public async Task<Product> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug("Редактирование продукта с именем {0}", request.Name);

            var product = await _db.Products.FindAsync(request.ProductId);

            if(product is null)
            {
                _logger.Debug("Продукта с именем {0 не найден}", request.Name);
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            product.SetPrice(request.Price);
            product.SetTitle(request.Name);
            product.SetDescription(request.Description);
            product.SetVendorId(request.VendorId);
            product.SetCategoryId(request.CategoryId);

            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Редактирование продукта с именем {0} завершено.", request.Name);

            return product;
        }
    }
}