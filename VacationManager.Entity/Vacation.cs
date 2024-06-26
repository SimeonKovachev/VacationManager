﻿using System;
using System.ComponentModel.DataAnnotations;
using VacationManager.Enums;

namespace VacationManager.Entity
{
    public class Vacation
    {
        public int ID { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Please choose Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "Please choose End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Please choose the Type of Vacation")]
        public VacationTypeEnum Type { get; set; }

        [Display(Name = "Worker")]
        public int WorkerID { get; set; }

        public Worker Worker { get; set; }

    }
}
