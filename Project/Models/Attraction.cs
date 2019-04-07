namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attraction")]
    public partial class Attraction
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(1000)]
        public string Coordinates { get; set; }

        public Guid IdCity { get; set; }

        public virtual City City { get; set; }
    }
}
