using TIMSBack.Application.Common.Models;
using System.Threading.Tasks;
using TIMSBack.Application.Login.Queries;
using TIMSBack.Domain.Entities.Auth;

namespace TIMSBack.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);

        Task<LoginResultDto> Login(string userName, string password);

        Task<string> Register(RegisterModel model);
    }
}
