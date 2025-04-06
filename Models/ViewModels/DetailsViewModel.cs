using System.ComponentModel.DataAnnotations;

namespace COLLEGE.Models.ViewModels
{
    public class DetailsViewModel
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }
        public string Address { get; set; }

        public int Grade { get; set; }

        public int ParentId { get; set; }
        public string ParentName { get; set; }

        [Phone]
        public string Phone { get; set; }

        public IFormFile Photo { get; set; }

        public string PhotoPath { get; set; }

        //Teacher

        public int TeacherId { get; set; }

        public string TeacherName { get; set; }
       public string Subject { get; set; }
        public bool Status { get; set; } = true;




    }
}
