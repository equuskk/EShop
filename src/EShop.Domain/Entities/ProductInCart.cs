using System;

namespace EShop.Domain.Entities
{
    public class ProductInCart
    {
        public int Id { get; private set; }
        public string UserId { get; private set; }
        public int ProductId { get; private set; }
        public int OrderId { get; private set; }

        public int Quantity { get; private set; }


        public virtual ShopUser User { get; private set; }
        public virtual Product Product { get; private set; }
        public virtual Order Order { get; private set; }

        private ProductInCart()
        {
        }

        public ProductInCart(string userId, int productId, int quantity, int orderId = 0)
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

        public void SubQuantity(int quantity)
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

            Quantity -= quantity;
        }

        private void SetUserId(string userId)
        {
            if(string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("userId is empty", nameof(userId));
            }

            if(!Guid.TryParse(userId, out _))
            {
                throw new ArgumentException("incorrect GUID", nameof(userId));
            }

            UserId = userId;
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