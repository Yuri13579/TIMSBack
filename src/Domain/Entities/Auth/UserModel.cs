using Microsoft.AspNet.Identity;

namespace TIMSBack.Domain.Entities.Auth
{
    public class UserModel : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
