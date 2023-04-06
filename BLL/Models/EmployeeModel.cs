using System;

namespace BLL.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Title { get; set; }
        public CompanyModel Company { get; set; }
    }
}
