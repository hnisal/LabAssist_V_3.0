using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models
{
    public class JobCommision
    {
        public int JobID { get; set; }
        public int InvocieID { get; set; }
        public double Earning { get; set; }
        public DateTime CreatedDate { get; set; }

        //--------------------------------------
        public Job Job { get; set; }
        public Invoice Invoice { get; set; }
    }
}
