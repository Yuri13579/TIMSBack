using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIMSBack.Application.Common.Exceptions;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int ProductUnitId { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.ProductId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            entity.Name = request.Name;
            entity.ProductUnitId = request.ProductUnitId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
