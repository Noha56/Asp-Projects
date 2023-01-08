using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DBApp2.Models;

namespace DBApp2.Data
{
    public class DBApp2Context : DbContext
    {
        public DBApp2Context (DbContextOptions<DBApp2Context> options)
            : base(options)
        {
        }

        public DbSet<DBApp2.Models.Student> Student { get; set; } = default!;
    }
}
