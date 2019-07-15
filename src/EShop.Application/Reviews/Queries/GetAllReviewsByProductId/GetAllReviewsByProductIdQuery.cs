using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Reviews.Queries.GetAllReviewsByProductId
{
    public class GetAllReviewsByBpoductIdQuery : IRequest<ReviewsViewModel>
    {
        public int ProductId { get; set; }
    }
}
