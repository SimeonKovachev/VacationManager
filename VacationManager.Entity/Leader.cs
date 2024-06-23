using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VacationManager.Entity
{
    public class Leader
    {
        public int ID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Profession")]
        public string Profession { get; set; }


        public ICollection<Team> Teams { get; set; }
    }
}
