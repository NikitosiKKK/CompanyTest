using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class EmployeeUpdateModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Title { get; set; }
    }
}
