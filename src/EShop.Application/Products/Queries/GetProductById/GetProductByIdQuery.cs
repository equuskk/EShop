using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
