using System;
using System.Runtime.CompilerServices;

namespace EShop.Domain.Entities
{
    public class Review
    {
        public int Id { get; private set; }

        public int ShopUserId { get; private set; }
        public int ProductId { get; private set; }

        public string Text { get; private set; }
        public int Rate { get; private set; }
        public DateTime Date { get; private set; } // автогенерация

        public virtual ShopUser ShopUser { get; private set; }
        public virtual Product Product { get; private set; }

        private Review()
        {
            Date = DateTime.UtcNow;
        }

        public Review(string text, int rate, int userId, int productId) : this()
        {
            SetText(text);
            SetRate(rate);
            SetUserId(userId);
            SetProductId(productId);
        }

        public void SetText(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("text is empty", nameof(text));
            }

            Text = text;
        }

        public void SetRate(int rate)
        {
            if(rate <= 0 || rate > 5) // оценка от 1 до 5
            {
                throw new ArgumentOutOfRangeException(nameof(rate), rate, "rate should be in the range of 1 to 5");
            }

            Rate = rate;
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