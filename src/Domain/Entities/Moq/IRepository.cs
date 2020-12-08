using System;
using System.Collections.Generic;
using System.Text;

namespace TIMSBack.Domain.Entities.Moq
{
    public interface IRepository
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        void Create(User user);
    }
}
