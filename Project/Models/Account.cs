namespace Project.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Account")]
    public partial class Account
    {
        public Guid Id { get; set; }

        [StringLength(120)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [StringLength(120)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required]
        [StringLength(120)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(120)]
        public string LastName { get; set; }

        [Required]
        [StringLength(120)]
        public string Country { get; set; }
    }
}
