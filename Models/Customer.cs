using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Data
{
    public class Customer
    {
        [Required]
        [Key]
        public int CustomerID { get; set; }
        [Required]
        [Display(Name = "Customer Type")]
        public string CustomerType { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}
