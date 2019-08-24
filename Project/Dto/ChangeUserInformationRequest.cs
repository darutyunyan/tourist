using System.ComponentModel.DataAnnotations;

namespace Project.Dto
{
    public class ChangeUserInformationRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "First Name")]
        [StringLength(120)]
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Last Name")]
        [StringLength(120)]
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Country")]
        [StringLength(120)]
        public string Country { get; set; }
    }
}