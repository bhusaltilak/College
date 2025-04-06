namespace COLLEGE.Models.DbEntities
{
    public class Parent
    {
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public String Phone { get; set; }
        public bool Status {  get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
