using MediatR;

namespace EShop.Application.Products.Commands.MakeOrder
{
    public class MakeOrderCommand : IRequest<bool>
    {
        public string ShopUserId { get; set; }
    }
}