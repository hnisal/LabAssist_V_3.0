using LabAssist_V_3._0.Data;
using LabAssist_V_3._0.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models
{
    public class Item
    {
        [Required]
        [Key]
        public int ItemID { get; set; }
        [StringLength(250)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }// UFR, FBS..(Test), "Inventory Item"
        [Required]
        [Display(Name = "Item Catergoty")]
        public ItemCatergory? ItemCatergory { get; set; }
        [Display(Name = "Unit Of Mesurement")]
        public UOM UOM { get; set; }
        [Required(ErrorMessage = "Please enter Item price")]
        [DataType(DataType.Currency)]
        [Display(Name = "Item Price")]
        public double ItemPrice { get; set; }


        //-----------------------------------------------
        public ICollection<TestComponent> TestCompoent { get; set; }
        public ICollection<InvoiceItem> InvoiceItem { get; set; }

    }
}
