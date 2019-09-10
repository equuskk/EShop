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
            var product = new Product(request.Name, request.Description, request.Price,
                                      request.VendorId, request.CategoryId, request.ImagePath);

            _logger.Debug("Добавление продукта с именем {0}", request.Name);

            _db.Products.Add(product);
            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Продукта с именем {0} добавлен. Его ID : {1}", request.Name, product.Id);

            return product.Id;
        }
    }
}