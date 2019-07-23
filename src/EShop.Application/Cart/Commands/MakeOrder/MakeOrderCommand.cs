using MediatR;

namespace EShop.Application.Cart.Commands.MakeOrder
{
    public class MakeOrderCommand : IRequest<bool>
    {
        public string ShopUserId { get; set; }
    }
}