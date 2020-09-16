using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models.ViewModels
{
    public class InvoicePrint
    {
        public Customer Customer { get; set; }
        public IEnumerable<Payment> Payment { get; set; }
        public IEnumerable<Item> Item { get; set; }
        public IEnumerable<Invoice> Invoice { get; set; }
        public IEnumerable<InvoiceItem> InvoiceItem { get; set; }

    }
}
