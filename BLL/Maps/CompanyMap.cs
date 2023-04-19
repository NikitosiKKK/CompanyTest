using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Maps
{
    public static class CompanyMap
    {
        public static CompanyModel Map(CompanyEntity company)
        {
            var companyModel = new CompanyModel
            {
                Id = company.Id,
                Name = company.Name,
                Form = company.Form,
                
                Employees = company.Employees.Select(e => EmployeeMap.Map(e)).ToList()
            };

            return companyModel;
        }

        public static CompanyEntity Map(CompanyModel company)
        {
            var companyEntity = new CompanyEntity
            {
                Id = company.Id,
                Name = company.Name,
                Form = company.Form,
                Employees = company.Employees.Select(e => EmployeeMap.Map(e)).ToList()
            };

            return companyEntity;
        }
        public static CompanyEntity Map(CompanyUpdateModel company)
        {
            var updatedEntity = new CompanyEntity
            {
                Name = company.Name,
                Form = company.Form
            };

            return updatedEntity;
        }
    }
}
