using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacationManager.Entity
{
    public class Worker
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Profession { get; set; }


        public ICollection<Team> Teams { get; set; }
    }
}
