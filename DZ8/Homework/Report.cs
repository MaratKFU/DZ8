using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Report
    {
        public string reportText {get;set;}
        public DateTime completionDate{ get; set; }
        public string executor{ get; set; }

        public Report(string text, DateTime compDate, string exec)
        {
            this.reportText = text;
            this.completionDate = compDate;
            this.executor = exec;
        }
    }
}
