using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Domain.Entities;

namespace TIMSBack.Application.Trademarks.Queries.GetTrademarks
{
    public class GetTrademarksQuery : IRequest<List<Trademark>>
    {
    }
    public class GetTrademarksQueryHandler : IRequestHandler<GetTrademarksQuery, List<Trademark>>
    {
        private readonly IApplicationDbContext _context;
       

        public GetTrademarksQueryHandler(IApplicationDbContext context
            
        )
        {
            _context = context;
           
        }
        
        public async Task<List<Trademark>> Handle(GetTrademarksQuery request, CancellationToken cancellationToken)
        {
            List<Trademark> result = _context.Trademarks.ToList();
            return  await Task.FromResult(result) ;
        }
    }
}
