using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public enum TaskStatus_
    {
        Appointed,
        Working,
        Reviewing,
        Completed,
        Deleted
    }
    internal class ProjectTask
    {
        public string description { get; set; }
        public DateTime deadline { get; set; }
        public string initiator { get; set; }
        public string executor { get; set; }
        public TaskStatus_ status { get; set; }
        public List<Report> reports { get; set; }
        public ProjectTask(string initiator, DateTime deadline)
        {
            description = "";
            this.deadline = deadline;
            this.initiator = initiator;
            executor = "";
            status = TaskStatus_.Appointed;
            reports = new List<Report>();
        }
    }
}
