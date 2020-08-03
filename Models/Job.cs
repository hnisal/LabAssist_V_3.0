using LabAssist_V_3._0.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models
{
    public class Job
    {
        [Required]
        [Key]
        public int JobID { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "Doctor Name")]
        public int DoctorID { get; set; }
        [Required]
        [Display(Name = "Job Date")]
        public DateTime JobDate{ get; set; }
        [Required]
        [Display(Name = "Branch")]
        public Branch Branch { get; set; }


        //-----------------------------------------------
        public Customer Customer { get; set; }
        public Doctor Doctor { get; set; }

    }
}
