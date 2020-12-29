using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TIMSBack.Application.Login;
using TIMSBack.Domain.Entities;
using TIMSBack.Domain.Entities.Auth;
using TIMSBack.Infrastructure.Identity;

namespace TIMSBack.WebUI.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ApiController
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")] //
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.UserName, model.Password);

            if (user == null)
                return BadRequest(new { message = "UserName or password is incorrect" });

            return Ok(user);
        }
        
        [AllowAnonymous]
        [HttpPost("register")] //
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
        {
            
            var user = await _userService.RegisterAsync(model);

            if (user == null)
                return BadRequest(new { message = "Register failed" });

            return Ok(user);
        }


       // [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            // only allow admins to access other user records
           // var currentUserId = int.Parse(User.Identity.Name);
            if (id != User.Identity.Name && !User.IsInRole(Role.Admin))
                return Forbid();

            var user = _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
