using LabAssist_V_3._0.Data;
using LabAssist_V_3._0.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models
{
    public class TestComponent
    {
        [Required]
        [Key]
        public int TestComponentID { get; set; }
        [Required]
        [Display(Name = "Item Name")]
        public int ItemID { get; set; }
        [Required]
        [Display(Name = "Component Name")]
        public string ComponentName { get; set; }
        [Required]
        [Display(Name = "Unit Of Mesurement")]
        public UOM UOM { get; set; }
        [Display(Name = "Reference Range")]
        public float RefRange { get; set; }
        public decimal Percentage { get; set; }
        [Display(Name = "TM")]
        public float CTM { get; set; }
        [Display(Name = "Maximum")]
        public float CMax { get; set; }
        [Display(Name = "Minimum")]
        public float CMin { get; set; }
        

        //----------------------------------------------
        public Item Item { get; set; }

    }
}
