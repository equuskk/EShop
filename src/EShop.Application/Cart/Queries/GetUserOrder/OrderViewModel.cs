using System;
using System.Collections.Generic;
using System.Text;
using EShop.Domain.Entities;

namespace EShop.Application.Cart.Queries.GetUserOrder
{
    public class OrderViewModel
    {
        public ProductInCart[] ProductInCarts{ get; set; }
    }
}
