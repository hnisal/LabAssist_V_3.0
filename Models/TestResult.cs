using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabAssist_V_3._0.Models
{
    public class TestResult
    {
        public int TestResultID { get; set; }
        public int TestComponentID { get; set; }
        public int JobID { get; set; }
        public string Result { get; set; }

        public TestComponent TestComponent { get; set; }
        public Item Item { get; set; }
        public Job Job { get; set; }




    }
}
