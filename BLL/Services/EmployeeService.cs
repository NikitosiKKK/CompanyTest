using BLL.Interfaces;
using BLL.Maps;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeModel Create(EmployeeModel employeeModel)
        {
            var employeeEntity = EmployeeMap.Map(employeeModel);
            var createEntity = _employeeRepository.Create(employeeEntity);
            return EmployeeMap.Map(createEntity);
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }

        public EmployeeModel Get(int id)
        {
            var employeeEntity = _employeeRepository.Get(id);

            return EmployeeMap.Map(employeeEntity);
        }

        public List<EmployeeModel> List()
        {
            var employeeEntities = _employeeRepository.List();

            var employeeModels = employeeEntities.Select(p => EmployeeMap.Map(p));
            return employeeModels.ToList();
        }

        public EmployeeModel Update(int id, EmployeeUpdateModel employeeModel)
        {
            var employeeEntity = EmployeeMap.Map(employeeModel, id);
            var updatedEntity = _employeeRepository.Update(employeeEntity);
            return EmployeeMap.Map(updatedEntity);
        }
    }
}
