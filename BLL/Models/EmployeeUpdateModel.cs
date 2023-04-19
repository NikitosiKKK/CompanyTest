using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class EmployeeUpdateModel
    {
        [Required(ErrorMessage = "Insert name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The lenght of the name should be form 2 to 50")]
        [RegularExpression(@"^[^0-9 ]+$", ErrorMessage = "Сannot contain spaces or numbers")]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Insert name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The lenght of the name should be form 2 to 50")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Insert name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The lenght of the name should be form 2 to 50")]
        public string Patronymic { get; set; }
        [Required(ErrorMessage = "Insert name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The lenght of the name should be form 2 to 50")]
        public string Title { get; set; }
        public int? CompanyId { get; set; }
    }
}
