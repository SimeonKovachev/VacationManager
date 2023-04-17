using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Enums;



namespace VacationManager.Entity
{
    public class Vacation
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please choose Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please choose End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Please choose the Type of Vacation")]
        public VacationTypeEnum Type { get; set; }

    }
}
