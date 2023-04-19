using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insert name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The lenght of the name should be form 2 to 50")]
        public string Name { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Insert surname")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The lenght of the surname should be form 2 to 50")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Insert patronymic")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The lenght of the patronymic should be form 2 to 50")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Insert title")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The lenght of the title should be form 2 to 50")]
        public string Title { get; set; }
        public int? CompanyId { get; set; }
    }
}
