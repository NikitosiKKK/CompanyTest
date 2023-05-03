using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class DBCreation:IDBCreation
    {
        private readonly string _connectionString;
        public DBCreation(string connectionString) {

            _connectionString = connectionString;

        }
        public void CompanyCreation()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = "CREATE TABLE Company(Id int PRIMARY KEY IDENTITY(1,1),Name varchar(30),Form varchar(30))";
            db.Execute(sqlQuery);
            sqlQuery = "INSERT INTO Company (Name, Form) VALUES ('OMA','OOO'),('Sushi Planet','ZAO'),('First Trans','ZAO')";
            db.Execute(sqlQuery);

        }

        public void EmployeeCreation() {
            using IDbConnection db = new SqlConnection(_connectionString);
            var sqlQuery = "CREATE TABLE Employee(Id int IDENTITY(1,1),Name varchar(30),Surname varchar(30),Patronymic varchar(30),Title varchar(30),Date datetime DEFAULT(getdate()),CompanyId int REFERENCES Company(Id))";
            db.Execute(sqlQuery);
            sqlQuery = "INSERT INTO Employee (Name, Surname, Patronymic, Title, CompanyId) VALUES ('Karina','Kaptur','Nikolaevna','Sushi-master',2),('Mikita','Poleshchuk','Sergeevich','Driver',3),('Klim','Poleshchuk','Sergeevich','Electrician',1)";
            db.Execute(sqlQuery);
        }
    }
}
