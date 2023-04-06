using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Form { get; set; }
        public List<EmployeeModel> Emloyees { get; set; } = new List<EmployeeModel>();
    }
}
