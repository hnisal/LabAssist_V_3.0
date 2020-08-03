using LabAssist_V_3._0.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models
{
    public class Payment
    {
        [Required]
        [Key]
        public int PaymentID { get; set; }
        [Required]
        public int InvoiceID { get; set; }
        [Required]
        [Display(Name = "Paymnt Method")]
        public PaymentMethod PaymentMethod { get; set; } //Cash Card
        [Required]
        [Display(Name = "Payment Type")]
        public PaymentType PaymentType { get; set; } //advance Final
        [Required]
        [Display(Name = "Payment Amount")]
        public float PaymentAmount { get; set; }


        //----------------------------------------------
        public Invoice Invoice { get; set; }
    }
}
