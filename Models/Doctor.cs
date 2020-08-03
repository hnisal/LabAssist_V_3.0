using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models
{
    public class Doctor
    {
        [Required]
        [Key]
        public int DoctorID { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Doctor Name")]

        public string DoctorName { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Phone]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [StringLength(100)]
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }


        //------------------------------------------
        public ICollection<Doctor> Doctors { get; set; }

    }
}
