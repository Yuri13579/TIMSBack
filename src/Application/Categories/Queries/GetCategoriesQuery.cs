using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Application.Trademarks.Queries.GetTrademarks;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Application.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<List<Category>>
    {
    }

    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
    {
        private readonly IApplicationDbContext _context;
        
        public GetCategoriesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            List<Category> result = _context.Categories.ToList();
            return await Task.FromResult(result);
        }
    }
}
