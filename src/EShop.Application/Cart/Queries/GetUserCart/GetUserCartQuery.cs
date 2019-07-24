using MediatR;

namespace EShop.Application.Cart.Queries.GetUserCart
{
    public class GetUserCartQuery : IRequest<CartViewModel>
    {
        public string ShopUserId { get; set; }
    }
}