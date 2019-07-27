using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Cart.Commands.MakeOrder
{
    public class MakeOrderCommand : IRequest<bool>
    {
        public string ShopUserId { get; }

        [JsonConstructor]
        public MakeOrderCommand(string shopUserId)
        {
            ShopUserId = shopUserId;
        }
    }
}