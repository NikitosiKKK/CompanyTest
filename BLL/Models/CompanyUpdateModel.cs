using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CompanyUpdateModel
    {
        [Required(ErrorMessage = "Введите имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 50 символов")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите форму")]
        [RegularExpression("ZAO |OOO", ErrorMessage = "Неверно введена форма")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Длина формы должна состоять из 3 символов")]
       public string Form { get; set; }
    }
}
