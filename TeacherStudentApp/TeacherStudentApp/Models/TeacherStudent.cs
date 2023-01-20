namespace TeacherStudentApp.Models
{
    public class TeacherStudent
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int StudentrId { get; set; }
        public Student Student { get; set; }


    }
}
