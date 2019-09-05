using EShop.Domain.Entities;

namespace EShop.Application.Cart.Queries.GetUserOrder
{
    public class OrderViewModel
    {
        public ProductInCart[] ProductInCarts { get; set; }
    }
}