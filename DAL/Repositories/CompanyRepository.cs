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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly string _connectionString;

        public CompanyRepository(string con)
        {
            _connectionString = con;
        }

        public CompanyEntity Create(CompanyEntity companyEntity)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = $"INSERT INTO Company (Name, Form) VALUES (@Name, @Form)";
            db.Execute(sqlQuery, companyEntity);
            return companyEntity;
        }

        public void Delete(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = $"DELETE FROM Company where id='{id}'";
            db.Execute(sqlQuery);
        }

        public CompanyEntity Get(int id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);

            var sql = $"SELECT * FROM Company INNER JOIN Employee ON Employee.CompanyId=Company.Id WHERE Company.Id='{id}'";
            var company = connection.Query<CompanyEntity, EmployeeEntity, CompanyEntity>(sql, (company, employee) =>
            {
                company.Emloyees.Add(employee);
                return company;
            });

            return company.FirstOrDefault();
        }

        public List<CompanyEntity> List()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var companyEntities = db.Query<CompanyEntity>("SELECT * FROM Company");
            return companyEntities.ToList();
        }

        public CompanyEntity Update(CompanyEntity companyEntity, int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = $"UPDATE Company SET Name = @Name, Form=@Form WHERE id = '{id}'";
            db.Execute(sqlQuery, companyEntity);
            return companyEntity;
        }
    }
}
