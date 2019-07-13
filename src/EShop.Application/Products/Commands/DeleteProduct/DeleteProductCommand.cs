using MediatR;

namespace EShop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}