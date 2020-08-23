using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models.ViewModels
{
    public class TestItemData
    {
        public IEnumerable<Item> Item { get; set; }
        public IEnumerable<TestComponent> TestComponent { get; set; }
        public IEnumerable<InvoiceItem> InvoiceItem { get; set; }

    }
}
