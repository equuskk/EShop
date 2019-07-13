using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Application.Products.Commands.EditProduct
{
    public class EditProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
