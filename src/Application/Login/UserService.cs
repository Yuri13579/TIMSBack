using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TIMSBack.Application.Common.Interfaces;
using TIMSBack.Domain.Entities;
using TIMSBack.Domain.Entities.Auth;
using TIMSBack.Domain.Entities.Moq;

namespace TIMSBack.Application.Login
{
    public class UserService : IUserService
    {
        //// users hardcoded for simplicity, store in a db with hashed passwords in production applications
        //private List<UserModel> _users = new List<UserModel>
        //{
        //    new UserModel { Id = 1, FirstName = "Admin", LastName = "UserModel", UserName = "admin", Password = "admin", Role = Role.Admin },
        //    new UserModel { Id = 2, FirstName = "Normal", LastName = "UserModel", UserName = "user", Password = "user", Role = Role.UserModel }
        //};

        private readonly AppSettings _appSettings;
        private readonly IApplicationDbContext _context;
        private readonly IIdentityService _identityService;


        public UserService(IOptions<AppSettings> appSettings,
            IApplicationDbContext context,
            IIdentityService identityService)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _identityService = identityService;
        }

        public UserModel Authenticate(string username, string password)
        {
          //var user = _context.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);

          //  // return null if user not found
          //  if (user == null)
          //      return null;

          //  // authentication successful so generate jwt token
          //  var tokenHandler = new JwtSecurityTokenHandler();
          //  var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
          //  var tokenDescriptor = new SecurityTokenDescriptor
          //  {
          //      Subject = new ClaimsIdentity(new Claim[]
          //      {
          //          new Claim(ClaimTypes.Name, user.Id.ToString()),
          //          new Claim(ClaimTypes.Role, user.Role)
          //      }),
          //      Expires = DateTime.UtcNow.AddDays(7),
          //      SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
          //  };


          //  var token = tokenHandler.CreateToken(tokenDescriptor);
          //  user.Token = tokenHandler.WriteToken(token);

          //  return user.WithoutPassword();
          return null;
        }

        public IEnumerable<UserModel> GetAll()
        {
           // return _context.Users.WithoutPasswords();
            return null;
        }

        public UserModel GetById(string id)
        {
            //var user = _context.Users.FirstOrDefault(x => x.Id == id);
            //return user.WithoutPassword();
            return null;
        }

        public async Task<string> RegisterAsync(RegisterModel model)
        {
            var res = await _identityService.Register(model);
            return res;

            //EntityEntry<UserModel> res;
            //UserModel newUser = new UserModel
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    FirstName = model.FirstName,
            //    LastName = model.LastName,
            //    UserName = model.UserName,
            //    Password = model.Password,
            //    Role = Role.User
            //};

            //try
            //{
            //    var existingUser= _context.Users.SingleOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
            //    if (existingUser != null)
            //    {
            //        return null;
            //    }

            //    var us = _identityService.GetUserNameAsync(model.UserName);





            //    //var n = await _identityService.CreateUserAsync(model.UserName, model.Password);
            //    //var ii = await _identityService.GetUserNameAsync(n.UserId);
            //    var all0 = _context.Users.ToList();
            //    res = await _context.Users.AddAsync(newUser);

            //    var search = _context.Users.SingleOrDefault(x => x.UserName == newUser.UserName);
            //    var all = await _context.Users.ToListAsync();



            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message + e.StackTrace);
            //    throw;
            //}

            //return await Task.FromResult(res.Entity);

        }
    }
}
