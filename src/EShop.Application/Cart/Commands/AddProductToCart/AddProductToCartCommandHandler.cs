using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Cart.Commands.AddProductToCart
{
    public class AddProductToCartCommandHandler : IRequestHandler<AddProductToCartCommand, bool>
    {
        private readonly ProductsDbContext _db;

        public AddProductToCartCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            if(request.Quantity < 1)
            {
                return false;
            }

            var productInCart =
                _db.ProductsInCarts.FirstOrDefault(x => x.ProductId == request.ProductId &&
                                                        x.UserId == request.ShopUserId &&
                                                        x.OrderId == null);

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