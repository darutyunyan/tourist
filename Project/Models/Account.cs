namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Email { get; set; }

        [Required]
        [StringLength(120)]
        public string Password { get; set; }

        [Required]
        [StringLength(120)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(120)]
        public string LastName { get; set; }

        [StringLength(120)]
        public string Country { get; set; }
    }
}
