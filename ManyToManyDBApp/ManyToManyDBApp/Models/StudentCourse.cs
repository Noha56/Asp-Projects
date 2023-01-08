namespace ManyToManyDBApp.Models
{
    public class StudentCourse
    {
        //مابقدر اعمل dbcontext 
        public int StId { get; set; }
        public Student Student { get; set; }


        public int CourseId { get; set; }
        public Course Course { get; set; }




    }
}
