using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Title { get; set; }
        public int? CompanyId { get; set; }
    }
}
