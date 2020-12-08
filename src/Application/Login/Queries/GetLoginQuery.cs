using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Application.ProductLists.Queries.GetProducts;

namespace TIMSBack.Application.Login.Queries
{
    public class GetLoginQuery : IRequest<LoginResultDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class GetSelectedProductsQueryHandler : IRequestHandler<GetLoginQuery, LoginResultDto>
    {
        private readonly IIdentityService _identityService;
       
        public GetSelectedProductsQueryHandler(
            
            IIdentityService identityService)
        {
            _identityService = identityService;
        }


        public async Task<LoginResultDto> Handle(GetLoginQuery request, CancellationToken cancellationToken)
        {
            var result =  await _identityService.Login(request.UserName, request.Password);
            return result;
        }
    }
}
