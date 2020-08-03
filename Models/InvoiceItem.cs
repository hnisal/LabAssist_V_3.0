using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models
{
    public class InvoiceItem
    {

        public int InvoiceID { get; set; }
        public int ItemID { get; set; }



        //--------------------------------------
        public Invoice Invoice { get; set; }
        public Item Item { get; set; }
    }
}
