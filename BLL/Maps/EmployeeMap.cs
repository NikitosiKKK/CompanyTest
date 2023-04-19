using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Maps
{
    public static class EmployeeMap
    {
        public static EmployeeModel Map(EmployeeEntity employee)
        {
            if (employee != null)
            {
                var employeeModel = new EmployeeModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Patronymic = employee.Patronymic,
                    Date = employee.Date,
                    Title = employee.Title,
                    CompanyId = employee.CompanyId
                };

                return employeeModel;
            }
            
            return null;
        }

        public static EmployeeEntity Map(EmployeeModel employee)
        {
            var employeeEntity = new EmployeeEntity
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Date = employee.Date,
                Title = employee.Title,
                CompanyId = employee.CompanyId
            };

            return employeeEntity;
        }
        public static EmployeeEntity Map(EmployeeUpdateModel employee, int id)
        {
            var employeeEntity = new EmployeeEntity
            {
                Id = id,
                Name = employee.Name,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Date = employee.Date,
                Title = employee.Title,
                CompanyId = employee.CompanyId
            };

            return employeeEntity;
        }
    }
}
