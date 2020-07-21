using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Data
{
    public class InvoiceItem
    {
        [Required]
        [Key]
        public int InvoiceItemID { get; set; }
        public int ItemID { get; set; }
        public int LaboratoryID { get; set; }
        [Required]
        [Display(Name = "Unit Of Mesurement")]
        public UOM? UOM { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Price { get; set; }



        public Item Item { get; set; }
        public Laboratory Laboratory { get; set; }


    }
}
