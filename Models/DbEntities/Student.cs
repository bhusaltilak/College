namespace COLLEGE.Models.DbEntities
{
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }

        public int Grade { get; set; }

        public string PhotoPath { get; set; }
        public int ParentId {  get; set; }
        public Parent Parent { get; set; }
    }
}
