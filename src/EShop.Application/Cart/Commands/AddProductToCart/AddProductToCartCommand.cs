using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Cart.Commands.AddProductToCart
{
    public class AddProductToCartCommand : IRequest<Unit>
    {
        public string ShopUserId { get; }
        public int ProductId { get; }
        public int Quantity { get; }

        [JsonConstructor]
        public AddProductToCartCommand(string shopUserId, int productId, int quantity)
        {
            ShopUserId = shopUserId;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}