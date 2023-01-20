using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using e1.Models;

namespace e1.Data
{
    public class e1Context : DbContext
    {
        public e1Context (DbContextOptions<e1Context> options)
            : base(options)
        {
        }

        public DbSet<e1.Models.Student> Student { get; set; } = default!;
    }
}
