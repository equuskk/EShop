using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Products.Commands.Payment
{
    public class OrderPaymentCommand : IRequest<bool>
    {
        public string ShopUserId { get; set; }
    }
}
