using DAL.Entities;
using DAL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string con)
        {
            _connectionString = con;
        }

        public EmployeeEntity Create(EmployeeEntity employeeEntity)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = $"INSERT INTO Employee (Name, Surname, Patronymic, Title, Company) VALUES (@Name, @Surname, @Patronomic, @Title, @Company)";
            db.Execute(sqlQuery, employeeEntity);
            return employeeEntity;
        }

        public void Delete(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = $"DELETE FROM Employee where id='{id}'";
            db.Execute(sqlQuery);
        }

        public EmployeeEntity Get(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.QuerySingleOrDefault<EmployeeEntity>("SELECT * FROM Employee WHERE id = @id", new { id });
        }
        public EmployeeEntity Get2(int id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);

            var sql = $"SELECT * FROM Employee INNER JOIN Company ON Employee.CompanyId=Company.Id WHERE Employee.Id='{id}'";
            var employee = connection.Query<EmployeeEntity, CompanyEntity, EmployeeEntity>(sql, (employee, company) =>
            {
                employee.Company = company;
                return employee;    
            });

            return employee.FirstOrDefault();
        }

        public List<EmployeeEntity> List()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var employeeEntities = db.Query<EmployeeEntity>("SELECT * FROM Employee");
            return employeeEntities.ToList();
        }

        public EmployeeEntity Update(EmployeeEntity employeeEntity)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = $"UPDATE Employee SET Name = @Name, Surname=@Url ,Patronymic=@Patronymic, Title=@Title, Company=@Company WHERE id = '{employeeEntity.Id}'";
            db.Execute(sqlQuery, employeeEntity);
            return employeeEntity;
        }
    }
}
