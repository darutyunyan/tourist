using System.ComponentModel.DataAnnotations;

namespace Project.Dto
{
    public class LoginRequest
    {
        [StringLength(120)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [StringLength(120)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}