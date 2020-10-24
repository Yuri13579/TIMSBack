using TIMSBack.Application.Common.Models;
using System.Threading.Tasks;
using TIMSBack.Application.Login.Queries;

namespace TIMSBack.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);

        Task<UserInfoDto> Login(string userName, string password);
    }
}
