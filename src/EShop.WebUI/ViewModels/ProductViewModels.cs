using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
