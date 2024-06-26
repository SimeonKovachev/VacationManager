﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VacationManager.Entity
{
    public class Worker
    {
        public int ID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Profession")]
        public string Profession { get; set; }

        public ICollection<Team> Teams { get; set; }
        public ICollection<Vacation> Vacations { get; set; }
    }
}
