using BLL.Interfaces;
using BLL.Maps;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)

        {
        _userRepository= userRepository;
        }
        public List<UserModel> GetUsers()
        {
            var userEntities = _userRepository.GetUsers();

            var userModels = userEntities.Select(p => UserMap.Map(p));
            return userModels.ToList();
        }

        public void SetUser(UserModel userModel)
        {
            _userRepository.SetUser(UserMap.Map(userModel));
        }
    }
}
