using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Data
{
    public class Doctor
    {
        [Required]
        [Key]
        public int DoctorID { get; set; }
        [Required]
        [StringLength(250)]
        public string DoctorName { get; set; }
        [Required]
        [StringLength(250)]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string ContactNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string Designation { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string EmailAddress { get; set; }
    }
}
