using MediatR;

namespace EShop.Application.Cart.Commands.AddProductToCart
{
    public class AddProductToCartCommand : IRequest<bool>
    {
        public string ShopUserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}