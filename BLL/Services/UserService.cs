using BLL.Helpers;
using BLL.Interfaces;
using BLL.Maps;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public async Task<BaseResponse<ClaimsIdentity>> Register(UserModel model)
        {

            var users = GetUsers();
            UserModel user = users.Find(e => e.Email == model.Email);
            if (user != null)
            {
                return new BaseResponse<ClaimsIdentity>() { Description = "Пользователь с такой почтой уже существует" };
            }
            model.Role = Role.User;
            SetUser(model);
            var result = Authenticate(model);
            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                Description = "Пользователь создан",
                StatusCode = StatusCode.OK
            };
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(UserModel model)
        {
            var users = GetUsers();
            UserModel user = users.Find(e=> e.Email == model.Email);
            if (user == null)
            {
                return new BaseResponse<ClaimsIdentity>() { 
                    StatusCode= StatusCode.UserNotFound,
                    Description = "Пользователь не найден." 
                };
            }
            if (user.Password != Hashing.HashPassword(model.Password, Hashing.GenerateSalt())) {
                return new BaseResponse<ClaimsIdentity>() { Description = "Не верно указан пароль."};
            }

             var result = Authenticate(model);

            return new BaseResponse<ClaimsIdentity>() {
            Data= result,
            Description="Вход выполнен",
            StatusCode= StatusCode.OK
            };
        }
        public List<UserModel> GetUsers()
        {
            var userEntities = _userRepository.GetUsers();

            var userModels = userEntities.Select(p => UserMap.Map(p));
            return userModels.ToList();
        }

        public void SetUser(UserModel userModel)
        {
            var user = UserMap.Map(userModel);
            user.Password = Hashing.HashPassword(user.Password, Hashing.GenerateSalt());
            _userRepository.SetUser(user);
        }
        private ClaimsIdentity Authenticate(UserModel user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
               new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
               new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            // создаем объект ClaimsIdentity
            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
