using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class RegisterModel
    {
         
        [Required(ErrorMessage = "Email field is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is not correct")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password is not matches")]
        public string ConfirmPassword { get; set; }
    }   
}
