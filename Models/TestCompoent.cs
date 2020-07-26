using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LabAssist_V_3._0.Data
{
    public class TestCompoent
    {
        [Required]
        [Key]
        public int TestComponentID { get; set; }
        [Required]
        [Display(Name = "Component Name")]
        public string ComponentName{ get; set; }
        [Required]
        [Display(Name = "Unit Of Mesurement")]
        public UOM? UOM { get; set; }
        [Display(Name = "Reference Range")]
        public float RefRange { get; set; }
        public decimal Percentage { get; set; }
        [Display(Name = "TM")]
        public float CTM { get; set; }
        [Display(Name = "Maximum")]
        public float CMax { get; set; }
        [Display(Name = "Minimum")]
        public float CMin { get; set; }
        [Display(Name = "Item Name")]
        public int ItemID { get; set; }

        public Item Item { get; set; }
    }
}
