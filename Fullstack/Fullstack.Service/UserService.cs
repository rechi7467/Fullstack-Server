using Fullstack.Core.Models;
using Fullstack.Core.Repositories;
using Fullstack.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullstack.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetList()
        {
            return _userRepository.GetList();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User Add(User user)
        {
            return _userRepository.Add(user);
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
