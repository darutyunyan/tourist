using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.ModelView
{
    public partial class ChagePasswordViewModel
    {
        [Display(Name = "Current password")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Display(Name = "New password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Repeat new password")]
        [DataType(DataType.Password)]
        public string NewPasswordConfirm { get; set; }
    }
}