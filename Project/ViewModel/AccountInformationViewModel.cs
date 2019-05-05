using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.ModelView
{
    public partial class AccountInformationViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(120)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(120)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Country")]
        [StringLength(120)]
        public string Country { get; set; }
    }
}