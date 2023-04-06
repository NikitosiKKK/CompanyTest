using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Form { get; set; }
        public List<EmployeeEntity> Emloyees { get; set; } = new List<EmployeeEntity>();
    }
}
