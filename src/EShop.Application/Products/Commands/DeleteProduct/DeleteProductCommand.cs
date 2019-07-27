using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int ProductId { get; }

        [JsonConstructor]
        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
}