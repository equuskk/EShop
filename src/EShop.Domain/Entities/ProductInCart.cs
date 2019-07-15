using System;

namespace EShop.Domain.Entities
{
    public class ProductInCart
    {
        public int Id { get; private set; }
        public int ShopUserId { get; private set; }
        public int ProductId { get; private set; }
        public int OrderId { get; private set; }
        
        public int Quantity { get; private set; }
        

        public virtual ShopUser User { get; }
        public virtual Product Product { get; }
        public virtual Order Order { get; private set; }

        private ProductInCart() { }

        public ProductInCart(int userId, int productId, int quantity, int orderId = 0)
        {
            SetUserId(userId);
            SetProductId(productId);
            AddQuantity(quantity);
            SetOrderId(orderId);
        }

        public void SetOrderId(int orderId)
        {
            if(orderId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(orderId), orderId,
                                                      "orderId cannot be less than or equal to 0");
            }

            if(OrderId > 0) // если заказ уже оформлен
            {
                throw new ArgumentException("order has already been issued", nameof(orderId));
            }

            OrderId = orderId;
        }

        public void AddQuantity(int quantity)
        {
            if(quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), quantity,
                                                      "quantity cannot be less than or equal to 0");
            }

            if(OrderId > 0) // если заказ уже оформлен
            {
                throw new ArgumentException("order has already been issued");
            }

            Quantity += quantity;
        }

        private void SetUserId(int userId)
        {
            if(userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId), userId,
                                                      "userId cannot be less than or equal to 0");
            }

            ShopUserId = userId;
        }

        private void SetProductId(int productId)
        {
            if(productId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(productId), productId,
                                                      "productId cannot be less than or equal to 0");
            }

            ProductId = productId;
        }
    }
}