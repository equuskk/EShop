using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;
using Serilog;

namespace EShop.Application.Products.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public AddProductCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<AddProductCommandHandler>();
        }

        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug("Добавление продукта");

            var product = new Product(request.Name, request.Description, request.Price,
                                      request.VendorId, request.CategoryId, request.ImagePath);

            _db.Products.Add(product);
            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Продукт {0} успешно добавлен", product.Id);

            return product.Id;
        }
    }
}