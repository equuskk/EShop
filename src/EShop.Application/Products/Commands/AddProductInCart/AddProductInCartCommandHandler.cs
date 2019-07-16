using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Products.Commands.AddProductInCart
{
    public class AddProductInCartCommandHandler : IRequestHandler<AddProductInCartCommand, bool>
    {
        private readonly ProductsDbContext _db;

        public AddProductInCartCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(AddProductInCartCommand request, CancellationToken cancellationToken)
        {
            if(request.Quantity < 1)
            {
                return false;
            }

            var productInCart =
                _db.ProductsInCarts.FirstOrDefault(x => x.ProductId == request.ProductId &&
                                                        x.UserId == request.ShopUserId &&
                                                        x.OrderId == 0);

            if(productInCart is null)
            {
                productInCart = new ProductInCart(request.ShopUserId, request.ProductId, request.Quantity);

                _db.ProductsInCarts.Add(productInCart);
            }
            else
            {
                productInCart.AddQuantity(request.Quantity);
            }


            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}