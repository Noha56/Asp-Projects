using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using seedDbApp.Models;

namespace seedDbApp.Data
{
    public class seedDbAppContext : DbContext
    {
        public seedDbAppContext (DbContextOptions<seedDbAppContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelB)
        {
            base.OnModelCreating(modelB);
            modelB.Entity<Mobile>().HasData(
                new Mobile
                {
                    MobileId=1,
                    Model="Iphone1",
                    Price=800
                },
                 new Mobile
                 {
                     MobileId = 2,
                     Model = "Iphone2",
                     Price = 700
                 },
                  new Mobile
                  {
                      MobileId = 3,
                      Model = "Iphone3",
                      Price = 650
                  },
                   new Mobile
                   {
                       MobileId = 4,
                       Model = "Iphone4",
                       Price = 750
                   }
                );
        }

        public DbSet<seedDbApp.Models.Mobile> Mobile { get; set; } = default!;
    }
}
