using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using MediatR;

namespace EShop.Application.Products.Commands.DeleteProductFromCart
{
    public class DeleteProductFromCartCommandHandler : IRequestHandler<DeleteProductFromCartCommand, bool>
    {
        private readonly ProductsDbContext _db;

        public DeleteProductFromCartCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(DeleteProductFromCartCommand request, CancellationToken cancellationToken)
        {
            var productInCart =
                _db.ProductsInCarts.FirstOrDefault(x => x.ProductId == request.ProductId &&
                                                        x.UserId == request.ShopUserId &&
                                                        x.OrderId == 0);

            if(productInCart is null)
            {
                return false;
            }

            if(productInCart.Quantity - request.Quantity <= 0)
            {
                _db.ProductsInCarts.Remove(productInCart);
            }
            else
            {
                productInCart.SubQuantity(request.Quantity);
            }


            await _db.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}