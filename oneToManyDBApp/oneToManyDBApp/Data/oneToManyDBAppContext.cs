using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using oneToManyDBApp.Models;

namespace oneToManyDBApp.Data
{
    public class oneToManyDBAppContext : DbContext
    {
        public oneToManyDBAppContext (DbContextOptions<oneToManyDBAppContext> options)
            : base(options)
        {
        }

        public DbSet<oneToManyDBApp.Models.Department> Department { get; set; } = default!;

        public DbSet<oneToManyDBApp.Models.Employee> Employee { get; set; }
    }
}
