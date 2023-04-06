using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployeeService
    {
        public List<EmployeeModel> List();
        public EmployeeModel Get(int id);
        public EmployeeModel Update(int id, EmployeeUpdateModel employeeModel);
        public void Delete(int id);
        public EmployeeModel Create (EmployeeModel employeeModel);
    }
}
