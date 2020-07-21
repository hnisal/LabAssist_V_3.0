using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Data
{
    public class Laboratory
    {
        [Required]
        [Key]
        public int LaboratoryID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Laboratory Name")]
        public string LaboratoryName { get; set; }
        
        [StringLength(100)]
        public string Address { get; set; }  
        [Phone]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }


        public ICollection<InvoiceItem> InvoiceItem { get; set; }


    }
}
