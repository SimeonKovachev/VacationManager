﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VacationManager.Entity
{
    public class Project
    {
        public int ID { get; set; }

        [Display(Name= "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please choose Start Date")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please choose End Date")]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
