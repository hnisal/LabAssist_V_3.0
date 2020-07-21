using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Data
{
    public class Item
    {
        [Required]
        [Key]
        public int ItemID { get; set; }//FK Catergory
        [Required]
        [StringLength(250)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }// UFR, FBS..(Test), "Inventory Item"
        [Required]
        [Display(Name = "Catergoty")]
        public ItemCatergory? ItemCatergory { get; set; }
        [Required]
        [Display(Name = "Unit Of Mesurement")]
        public UOM? UOM { get; set; }
        [Required(ErrorMessage = "Please enter Item price")]
        [DataType(DataType.Currency)]
        [Display(Name = "Item Price")]
        public double? ItemPrice { get; set; }

        public ICollection<TestCompoent> TestCompoent { get; set; }
        public ICollection<InvoiceItem> InvoiceItem { get; set; }

    }
}
