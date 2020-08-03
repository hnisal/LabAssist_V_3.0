using LabAssist_V_3._0.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models
{
    public class CashBook
    {
        [Required]
        [Key]
        public int CashTableID { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public double Amount { get; set; }
        [Required]
        [Display(Name = "Cash Type ")]
        public CashBookType CashBookType { get; set; }
        public int PaymentID { get; set; }


        //------------------------------------------------
        public Payment Payment { get; set; }
    }
}
