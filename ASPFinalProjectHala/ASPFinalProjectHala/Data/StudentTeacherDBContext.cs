using ASPFinalProjectHala.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPFinalProjectHala.Data
{
    public class StudentTeacherDBContext : DbContext
    {
        public StudentTeacherDBContext(DbContextOptions<StudentTeacherDBContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTeacher>().HasKey(st => new { st.StudentId, st.TeacherId });
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentTeacher> StudentTeachers { get; set; }
    }
}


