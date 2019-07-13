using EShop.DataAccess;
using EShop.Domain.Entities;
using EShop.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EShop.Application.Products.Commands.EditProduct
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, Product>
    {
        private readonly ProductsDbContext _db;

        public EditProductCommandHandler(ProductsDbContext db)
        {
            _db = db;
        }

        public async Task<Product> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await  _db.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (product is null)
            {
                throw new NotFoundException("EditProduct",request.Id);
            }

            product.Price = request.Price;
            product.Title = request.Title;
            product.Description = request.Description;

            await _db.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}
