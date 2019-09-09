using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Products.Commands.AddProduct
{
    public class AddProductCommand : IRequest<int>
    {
        public string Name { get; }
        public string Description { get; }
        public double Price { get; }
        public string ImagePath { get; }

        public int VendorId { get; }
        public int CategoryId { get; }

        [JsonConstructor]
        public AddProductCommand(string name, string description, double price, int vendorId, int categoryId,
                                 string imagePath)
        {
            Name = name;
            Description = description;
            Price = price;
            VendorId = vendorId;
            CategoryId = categoryId;
            ImagePath = imagePath;
        }
    }
}