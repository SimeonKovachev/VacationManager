using Microsoft.AspNet.Identity.EntityFramework;
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
    public class VacationContext : IdentityDbContext<VacationUser>
    {
        public VacationContext() : base("VacationConnection")
        {
        }

        public static VacationContext Create()
        {
            return new VacationContext();
        }

        public DbSet<Leader> Leaders { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Worker> Workers { get; set; }


    }
}
