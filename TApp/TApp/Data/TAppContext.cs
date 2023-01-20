using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TApp.Models;

namespace TApp.Data
{
    public class TAppContext : DbContext
    {
        public TAppContext (DbContextOptions<TAppContext> options)
            : base(options)
        {
        }

        public DbSet<TApp.Models.CustomerItem> CustomerItem { get; set; } = default!;

        public DbSet<TApp.Models.WearHouseItem> WearHouseItem { get; set; }
    }
}
