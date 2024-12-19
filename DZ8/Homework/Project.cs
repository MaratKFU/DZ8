using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public enum ProjectStatus
    {
        Project,
        Execution,
        Closed
    }
    internal class Project
    {
        public string description { get; set; }
        public DateTime deadline { get; set; }
        public string initiator { get; set; }
        public string projectManager { get; set; }
        public List<ProjectTask> tasks { get; set; }
        public ProjectStatus status { get; set; }
        public Project(string initiator, string projectManager, string description , DateTime deadline)
        {
            this.description = description;
            this.deadline = deadline;
            this.initiator = initiator;
            this.projectManager = projectManager;
            tasks = new List<ProjectTask>();
            status = ProjectStatus.Project;
        }
    }
}
