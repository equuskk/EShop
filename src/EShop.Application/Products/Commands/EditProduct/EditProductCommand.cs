using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Products.Commands.EditProduct
{
    public class EditProductCommand : IRequest<Product>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public int VendorId { get; set; }
        public int CategoryId { get; set; }
    }
}