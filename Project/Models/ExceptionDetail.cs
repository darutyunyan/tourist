namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExceptionDetail")]
    public partial class ExceptionDetail
    {
        public int Id { get; set; }

        public string ExceptionMessage { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string StackTrace { get; set; }

        public DateTime? Date { get; set; }
    }
}
