﻿using MediatR;

namespace EShop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int ProductId { get; set; }
    }
}