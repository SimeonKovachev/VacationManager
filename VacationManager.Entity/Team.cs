using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VacationManager.Entity
{
    public class Team
    {
        public int ID { get; set; }
        [Display(Name = "Team Name")]
        public string Name { get; set; }
        [Display(Name = "Project")]
        public int ProjectID { get; set; }
        [Display(Name = "Leader")]
        public int LeaderID { get; set; }
        [Display(Name = "Worker")]
        public int WorkerID { get; set; }
        [Display(Name = "Number of Workers")]
        public int NumOfWorkers { get; set; }

        public Project Project { get; set; }
        public Leader Leader { get; set; }
        public Worker Worker { get; set; }
    }
}

