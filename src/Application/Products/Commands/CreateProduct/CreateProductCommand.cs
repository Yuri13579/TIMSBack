using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Application.TodoItems.Commands.CreateTodoItem;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public int ProductId { get; set; }

        public string Name { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            
            var entity = new Product
            {
                ProductId = request.ProductId,
                Name = request.Name,
                ProductUnitId = ConstEntity.DefaultProductUnitId
            };

            _context.Products.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.ProductId;
        }
    }
}
