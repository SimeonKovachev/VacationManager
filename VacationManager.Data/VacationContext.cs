using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using VacationManager.Entity;

namespace VacationManager.Data
{
    public class VacationContext : DbContext
    {
        public VacationContext() : base("VacationConnection")
        {
        }

        public DbSet<Leader> Leaders { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Worker> Workers { get; set; }

        
        }
}
