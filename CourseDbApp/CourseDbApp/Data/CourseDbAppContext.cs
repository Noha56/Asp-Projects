using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CourseDbApp.Models;

namespace CourseDbApp.Data
{
    public class CourseDbAppContext : DbContext
    {
        public CourseDbAppContext (DbContextOptions<CourseDbAppContext> options)
            : base(options)
        {
        }

        public DbSet<CourseDbApp.Models.Course> Course { get; set; } = default!;
    }
}
