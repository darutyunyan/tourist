using System.ComponentModel.DataAnnotations;

namespace Project.Dto
{
    public class ChangePasswordRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(120)]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(120)]
        public string NewPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Password confirm is required")]
        [Display(Name = "Password Confirm")]
        [Compare("Password", ErrorMessage = "Password doesn't match!")]
        [DataType(DataType.Password)]
        [StringLength(120)]
        public string NewPasswordConfirm { get; set; }
    }
}