using LabAssist_V_3._0.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models
{
    public class User
    {
        [Required]
        [Key]
        public int UserID { get; set; }
        [Required]
        [Display(Name = "User type")]
        public UserType UserType { get; set; }
        [Required]
        [Display(Name = "User Name")]
        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }


        //---------------------------------------
        public ICollection<User> Users { get; set; }

    }
}
