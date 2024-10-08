using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcEmployee.Models
{
    public class MvcEmployeeContext : DbContext
    {
        public MvcEmployeeContext(DbContextOptions<MvcEmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<MvcEmployee.Models.Employee> Employee { get; set; }

    }
}
