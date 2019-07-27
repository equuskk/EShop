using EShop.Domain.Entities;
using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Products.Commands.EditProduct
{
    public class EditProductCommand : IRequest<Product>
    {
        public int ProductId { get; }
        public string Name { get; }
        public double Price { get; }
        public string Description { get; }

        public int VendorId { get; }
        public int CategoryId { get; }

        [JsonConstructor]
        public EditProductCommand(int productId, string name, double price, string description,
                                  int vendorId, int categoryId)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Description = description;
            VendorId = vendorId;
            CategoryId = categoryId;
        }
    }
}