using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models.ViewModels
{
    public class InvoiceFinal
    {
        public IEnumerable<Invoice> Invoice { get; set; }
        public IEnumerable<Item> Item { get; set; }
        public IEnumerable<InvoiceItem> InvoiceItem { get; set; }
        public IEnumerable<Customer> Customer { get; set; }
        public IEnumerable<Doctor> Doctor { get; set; }
        public IEnumerable<Payment> Payment { get; set; }

    }
}
