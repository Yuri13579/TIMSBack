using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIMSBack.Domain.Entities.Auth
{
    public static class ExtensionMethods
    {
        public static IEnumerable<UserModel> WithoutPasswords(this IEnumerable<UserModel> users)
        {
            if (users == null) return null;

            return users.Select(x => x.WithoutPassword());
        }

        public static UserModel WithoutPassword(this UserModel userModel)
        {
            if (userModel == null) return null;

            userModel.Password = null;
            return userModel;
        }
    }
}
