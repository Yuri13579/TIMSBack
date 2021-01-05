using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.Login.Queries;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController :ApiController
    {
        
        [HttpPost]
        public async Task<LoginResultDto> Login(GetLoginQuery command)
        {
            return await Mediator.Send(command);
        }
    }
}
