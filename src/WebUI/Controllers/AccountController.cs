using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Application.Customer.Queries;
using TIMSBack.Application.Login.Queries;

namespace TIMSBack.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController :ApiController
    {
        
        [HttpPost]
        public async Task<UserInfoDto> Login(GetLoginQuery command)
        {
            return await Mediator.Send(command);
        }
    }
}
