using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Data
{
    public class Invoice
    {
        [Required]
        [Key]
        public int InvocieID { get; set; }
        [Required]
        [Display(Name = "Prepared By")]
        public string PreparedBy { get; set; }
        [Required]
        [Display(Name = "Invoice Date")]
        public DateTime InvoiceData { get; set; }
        [Required]
        [Display(Name = "State")]
        public string State { get; set; }// Open,partially paid, paid
    }
}
