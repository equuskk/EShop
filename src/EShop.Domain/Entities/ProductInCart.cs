using System;

namespace EShop.Domain.Entities
{
    public class ProductInCart
    {
        public int Id { get; private set; }

        public ShopUser User { get; }
        public Product Product { get; }
        public int Quantity { get; private set; }
        public Order Order { get; private set; }

        private ProductInCart() { }

        public ProductInCart(ShopUser user, Product product, int quantity, Order order = null)
        {
            User = user ?? throw new ArgumentNullException(nameof(user), "user is null");
            Product = product ?? throw new ArgumentNullException(nameof(product), "product is null");
            AddQuantity(quantity);
        }

        private void AddQuantity(int quantity)
        {
            if(quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity,
                                                      "quantity cannot be less than or equal to 0");
            }

            Quantity += quantity;
        }
    }
}