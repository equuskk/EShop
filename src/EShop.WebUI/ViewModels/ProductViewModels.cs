using EShop.Application.Reviews.Queries.GetReviewsByProductId;
using EShop.Domain.Entities;

namespace EShop.WebUI.ViewModels
{
    public class ProductViewModels
    {
        public ReviewsViewModel Reviews { get; set; }
        public Product Product { get; set; }
    }
}