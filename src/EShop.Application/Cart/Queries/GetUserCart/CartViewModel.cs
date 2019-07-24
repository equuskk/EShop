using System.Linq;
using EShop.Domain.Entities;

namespace EShop.Application.Cart.Queries.GetUserCart
{
    public class CartViewModel
    {
        public Product[] Products { get; set; }
        public double TotalCost => Products.Sum(x => x.Price);
    }
}