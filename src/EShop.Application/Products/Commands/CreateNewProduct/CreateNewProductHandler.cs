using EShop.DataAccess;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Application.Products.Commands.CreateNewProduct
{
    public class CreateNewProductHandler : IRequestHandler<CreateNewProductCommand, Product>
    {
        private readonly ProductsDbContext _db;

        public CreateNewProductHandler(ProductsDbContext db)
        {
            _db = db;
        }
        public async Task<Product> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
        {
            Product pr = new Product
            {
                Id = request.Id,
                Description = request.Description,
                Price = request.Price,
                Title = request.Title,
            };

            _db.Products.Add(pr);
            await _db.SaveChangesAsync();

            return pr;
        }
    }
}

