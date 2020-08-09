using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models
{
    public class JobCommision
    {
        [Key, ForeignKey(nameof(Job))]
        public int JobID { get; set; }
        public double Earning { get; set; }
        public DateTime CreatedDate { get; set; }

        //--------------------------------------
        public Job Job { get; set; }
    }
}
