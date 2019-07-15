using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Products.Commands.AddProductInCart
{
    public class AddProductInCartCommand : IRequest<bool>
    {
        public string ShopUserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
