using System.ComponentModel.DataAnnotations;

namespace COLLEGE.Models.ViewModels
{
    public class StudentFeeViewModel
    {
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string Grade { get; set; }

        [Required]
        public int Id { get; set; }
        [Required]
        public string Month { get; set; }
        [Required]
        public int Amount { get; set; }

        public string AmountStatus { get; set; }
      

        public List<StudentFeeViewModel> Fees { get; set; } = new List<StudentFeeViewModel>();

    }
}
