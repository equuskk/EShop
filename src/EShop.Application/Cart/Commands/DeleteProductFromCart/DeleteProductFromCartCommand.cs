using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Cart.Commands.DeleteProductFromCart
{
    public class DeleteProductFromCartCommand : IRequest<Unit>
    {
        public int ProductId { get; }
        public int Quantity { get; }
        public string ShopUserId { get; }

        [JsonConstructor]
        public DeleteProductFromCartCommand(int productId, int quantity, string shopUserId)
        {
            ProductId = productId;
            Quantity = quantity;
            ShopUserId = shopUserId;
        }
    }
}