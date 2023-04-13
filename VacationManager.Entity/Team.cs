using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationManager.Entity
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ProjectID { get; set; }
        public int LeaderID { get; set; }
        public int WorkerID { get; set; }
        public int NumOfWorkers { get; set; }

        public Project Project { get; set; }
        public Leader Leader { get; set; }
        public Worker Worker { get; set; }
    }
}

