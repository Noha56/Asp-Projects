using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LaptopsIdentityApp.Models;

namespace LaptopsIdentityApp.Data
{
    public class LaptopsIdentityAppContext : DbContext
    {
        public LaptopsIdentityAppContext (DbContextOptions<LaptopsIdentityAppContext> options)
            : base(options)
        {
        }

        public DbSet<LaptopsIdentityApp.Models.Laptop> Laptop { get; set; } = default!;
    }
}
