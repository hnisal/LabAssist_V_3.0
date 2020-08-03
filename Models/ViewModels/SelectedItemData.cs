using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models.ViewModels
{
    public class SelectedItemData
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public bool Assigned { get; set; }
    }
}
