﻿using System.Threading;
using System.Threading.Tasks;
using EShop.DataAccess;
using EShop.Domain.Exceptions;
using MediatR;
using Serilog;

namespace EShop.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public DeleteCategoryCommandHandler(ApplicationDbContext db)
        {
            _db = db;
            _logger = Log.ForContext<DeleteCategoryCommandHandler>();
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.Debug("Удаление категории {0}", request.CategoryId);

            var category = await _db.Categories.FindAsync(request.CategoryId);

            if(category is null)
            {
                _logger.Debug("Категории {0} не найдена", request.CategoryId);
                throw new NotFoundException(nameof(category), request.CategoryId);
            }

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync(cancellationToken);

            _logger.Debug("Категории {0} удалена", request.CategoryId);

            return Unit.Value;
        }
    }
}