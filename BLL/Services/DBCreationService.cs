using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class DBCreationService : IDBCreationService
    {
        private readonly IDBCreation _dBCreation;
        public DBCreationService(IDBCreation dBCreation) { 
        _dBCreation= dBCreation;
        }
        public void CompanyCreation()
        {
            _dBCreation.CompanyCreation();
        }

        public void EmployeeCreation()
        {
            _dBCreation.EmployeeCreation();
        }
    }
}
