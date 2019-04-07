namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Route")]
    public partial class Route
    {
        public Guid Id { get; set; }

        [Required]
        public string Coordinates { get; set; }

        public Guid IdCity { get; set; }

        public virtual City City { get; set; }
    }
}
