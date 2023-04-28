using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Maps
{
    public class UserMap
    {
        public static UserModel Map(UserEntity userEntity) {
            var userModel = new UserModel
            {
                Id = userEntity.Id,
                Email = userEntity.Email,
                Password = userEntity.Password
            };
        return userModel;
        }
        public static UserEntity Map(UserModel userModel) {
            var userEntity = new UserEntity
            {
                Id = userModel.Id,
                Email = userModel.Email,
                Password = userModel.Password
            };
            return userEntity;
        }
    }
}
