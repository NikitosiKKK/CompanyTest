using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email field is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ,ErrorMessage = "Email is not correct")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
