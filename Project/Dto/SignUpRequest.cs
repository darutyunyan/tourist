using System.ComponentModel.DataAnnotations;

namespace Project.Dto
{
    public class SignUpRequest
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirm is required")]
        [Display(Name = "Password Confirm")]
        [Compare("Password", ErrorMessage = "Password doesn't match!")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}