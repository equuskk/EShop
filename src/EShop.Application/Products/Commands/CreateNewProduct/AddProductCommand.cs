using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Products.Commands.CreateNewProduct
{
    public class AddProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}