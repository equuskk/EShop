using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string ShopUserId { get; set; }
    }
}
