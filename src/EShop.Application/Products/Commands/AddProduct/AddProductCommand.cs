using MediatR;

namespace EShop.Application.Products.Commands.AddProduct
{
    public class AddProductCommand : IRequest<int>
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}