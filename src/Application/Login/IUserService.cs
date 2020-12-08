using System.Collections.Generic;
using System.Threading.Tasks;
using TIMSBack.Domain.Entities.Auth;

namespace TIMSBack.Application.Login
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        IEnumerable<UserModel> GetAll();
        UserModel GetById(string id);
        Task<string> RegisterAsync(RegisterModel model);
    }
}
