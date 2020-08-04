using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models.ViewModels
{
    public class InvoiceIndexData
    {
        public IEnumerable<Invoice> Invoice { get; set; }
        public IEnumerable<Item> Item { get; set; }
    }
}
