using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Data
{
    public class TestResult
    {
        [Required]
        [Key]
        public int TestResultID { get; set; }
        [Required]
        [Display(Name = "Test Result Date ")]
        public DateTime ResultDate { get; set; }
        [Required]
        public string Result { get; set; }

        
    }
}
