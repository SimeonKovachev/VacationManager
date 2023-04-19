using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationManager.Entity
{
    public class VacationWorker
    {

        [ForeignKey("Vacation")]
        public int VacationID { get; set; }
        public virtual Vacation Vacation { get; set; }


        [ForeignKey("Worker")]
        public int WorkerID { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
