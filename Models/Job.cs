using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Data
{
    public class Job
    {
        [Required]
        [Key]
        public int JobID { get; set; }       
        [Required]
        [Display(Name = "Job Card Date ")]
        public DateTime JobDate { get; set; }
    }
}
