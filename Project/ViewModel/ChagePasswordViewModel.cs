using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.ModelView
{
    public partial class ChagePasswordViewModel
    {
        [Required]
        [Display(Name = "Current password")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required]
        [Display(Name = "New password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "Repeat new password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and repeat new password do not match.")]
        public string NewPasswordConfirm { get; set; }
    }
}