using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Data
{
    public class Payment
    {
        [Required]
        [Key]
        public int PaymentID { get; set; }
        [Required]
        [Display(Name = "Preapared By")]
        public string PreparedBy { get; set; }
        [Required]
        [Display(Name = "Paymnt Method")]
        public string PaymentMethod { get; set; } //Cash Card
        [Required]
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; } //advance Final

    }
}
