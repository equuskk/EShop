using MediatR;

namespace EShop.Application.Products.Commands.DeleteProductFromCart
{
    public class DeleteProductFromCartCommand : IRequest<bool>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ShopUserId { get; set; }
    }
}