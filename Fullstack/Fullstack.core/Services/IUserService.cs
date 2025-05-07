using Fullstack.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullstack.Core.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetList();
        User GetById(int id);
        User Add(User user);
        User Update(User user);
        void Delete(int id);
    }
}
