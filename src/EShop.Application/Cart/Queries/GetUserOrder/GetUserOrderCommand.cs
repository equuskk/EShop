﻿using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Cart.Queries.GetUserOrder
{
    public class GetUserOrderCommand : IRequest<OrderViewModel>
    {
        [JsonConstructor]
        public GetUserOrderCommand(string shopUserId)
        {
            UserId = shopUserId;
        }

        public string UserId { get; }
    }
}