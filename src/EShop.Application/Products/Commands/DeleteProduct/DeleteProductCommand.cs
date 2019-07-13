using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
