namespace COLLEGE.Models.DbEntities
{
    public class StudentFee
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Grade { get; set; }
        public string Month { get; set; }
        public int Amount { get; set; }
        public string AmountStatus { get; set; }
        public bool Status { get; set; }
    }
}
