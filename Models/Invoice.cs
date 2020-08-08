using LabAssist_V_3._0.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models
{
    public class Invoice
    {
        [Required]
        [Key]
        public int InvocieID { get; set; }
        [Required]
        public int JobID { get; set; }
        [Required]
        [Display(Name = "Prepared By")]
        public int UserID { get; set; }
        [Required]
        [Display(Name = "Invoice Date")]
        public DateTime InvoiceData { get; set; }
        [Required]
        [Display(Name = "State")]
        public InvoiceState InvoiceState { get; set; }
        [Display(Name = "Invoice Total")]
        public double InvoiceTotal { get; set; }


        //-------------------------------------------------
        public User User { get; set; }
        public Job Job { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<InvoiceItem> InvoiceItem { get; set; }




    }
}
