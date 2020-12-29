using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TIMSBack.Application.Login.Queries;
using TIMSBack.Domain.Entities.Auth;
using TIMSBack.Domain.Entities.Moq;
using TIMSBack.Infrastructure.Services;


namespace TIMSBack.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }
        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return await DeleteUserAsync(user);
            }

            return Result.Success();
        }

        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public async Task<LoginResultDto> Login(string userName, string password)
        {
           var findByEmail = await _userManager.FindByEmailAsync(userName);
            
            if (findByEmail != null)
            {
                var result = await _userManager.CheckPasswordAsync(findByEmail, password);
              
                if (result)
                {
                    List<Claim> myClaims = new List<Claim>();
                    myClaims.Add(new Claim("Role", "UserModel"));
                    var roles = new JwtSecurityToken(claims: myClaims);
                    var token = new JwtSecurityTokenHandler().WriteToken(roles);

                    return new LoginResultDto {Token = token.ToString()};
                }
                return null;
            }

            return null;

        }

        public async Task<string> Register(RegisterModel model)
        {

            ApplicationUser user = new ApplicationUser { Email = model.UserName, UserName = model.UserName };
            // добавляем пользователя
          
            var create = await _userManager.CreateAsync(user, model.Password);
            if (create.Succeeded)
            {
                             
                // генерация токена для пользователя
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string callbackUrl = "sdasd";

                //var callbackUrl = Url.Action(
                //    "ConfirmEmail",
                //    "Account",
                //    new { userId = user.Id, code = code },
                //    protocol: HttpContext.Request.Scheme);

                try
                {
                    EmailService emailService = new EmailService();
                    await emailService.SendEmailAsync(model.UserName, "Confirm your account",
                        $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>link</a>");

                    //return Content(
                    //    "Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
                    return new string("Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
                }
                catch (Exception e)
                {
                    return new string(e.Message + e.StackTrace);
                }
              

            }
            else
            {
                string error = null;
                foreach (var er in create.Errors)
                {
                    error += er.Code + " " + er.Description;
                }

                return error;
            }

        }

    }
}
