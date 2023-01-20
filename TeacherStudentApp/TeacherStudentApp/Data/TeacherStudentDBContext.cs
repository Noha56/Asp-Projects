using Microsoft.EntityFrameworkCore;
using TeacherStudentApp.Models;

namespace TeacherStudentApp.Data
{
    public class TeacherStudentDBContext:DbContext
    {
        public TeacherStudentDBContext(DbContextOptions<TeacherStudentDBContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherStudent>().HasKey(st => new { st.TeacherId, st.StudentrId });
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherStudent> TeacherStudents { get; set; } = default!;

    }
}
