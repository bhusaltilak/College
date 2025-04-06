namespace COLLEGE.Models.DbEntities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Subject { get; set; }
        public string PhotoPath { get; set; }

        public bool Status { get; set; } =true;
    }
}
