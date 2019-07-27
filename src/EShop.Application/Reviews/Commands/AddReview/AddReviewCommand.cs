using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Reviews.Commands.AddReview
{
    public class AddReviewCommand : IRequest<int>
    {
        public string ShopUserId { get; }
        public int ProductId { get; }

        public string Text { get; }
        public int Rate { get; }

        [JsonConstructor]
        public AddReviewCommand(string shopUserId, int productId, string text, int rate)
        {
            ShopUserId = shopUserId;
            ProductId = productId;
            Text = text;
            Rate = rate;
        }
    }
}