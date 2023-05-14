using BLL.Helpers;
using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        public List<UserModel> GetUsers();
        public void SetUser(UserModel userModel);

        public  Task<BaseResponse<ClaimsIdentity>> Register(UserModel user);
        public Task<BaseResponse<ClaimsIdentity>> Login(UserModel user);
    }
}
