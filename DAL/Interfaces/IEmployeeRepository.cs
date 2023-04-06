using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        public List<EmployeeEntity> List();
        public EmployeeEntity Get(int id);
        public EmployeeEntity Update(EmployeeEntity employeeEntity);
        public void Delete(int id);
        public EmployeeEntity Create(EmployeeEntity employeeEntity);
    }
}
