using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.ModelView
{
    public partial class ContactUsViewModel
    {
        [Required(ErrorMessage = "Topic is required")]
        [Display(Name = "Topic*")]
        public string Topic { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email address*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [Display(Name = "Country*")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Text is required")]
        [Display(Name = "Message text*")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
    }
}