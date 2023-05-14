using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Net.Http;
using System.Security.Claims;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<UserEntity> GetUsers()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var userEntities = db.Query<UserEntity>("SELECT * FROM Users");
            return userEntities.ToList();
        }

        public void SetUser(UserEntity userEntity)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = $"INSERT INTO Users (Email, Password, Role) VALUES (@Email, @Password, @Role)";
            db.Execute(sqlQuery, userEntity);
        }
    }
}
