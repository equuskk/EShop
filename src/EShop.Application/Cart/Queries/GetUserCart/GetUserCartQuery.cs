using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Cart.Queries.GetUserCart
{
    public class GetUserCartQuery : IRequest<CartViewModel>
    {
        public string ShopUserId { get; }

        [JsonConstructor]
        public GetUserCartQuery(string shopUserId)
        {
            ShopUserId = shopUserId;
        }
    }
}