using System;

namespace EShop.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public DateTime OrderDate { get; private set; } // автогенерация
        public double Cost { get; private set; }

        private Order()
        {
            OrderDate = DateTime.UtcNow;
        }

        public Order(double cost) : this()
        {
            SetCost(cost);
        }

        private void SetCost(double cost) //TODO:
        {
            if(cost <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(cost), cost, "cost cannot be less than or equal to 0");
            }

            Cost = cost;
        }
    }
}