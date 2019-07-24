﻿using MediatR;

namespace EShop.Application.Products.Commands.AddProduct
{
    public class AddProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public int VendorId { get; set; }
        public int CategoryId { get; set; }
    }
}