using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace COLLEGE.Models.ViewModels
{
    public class TeacherViewModel
    {
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Teacher name is required.")]
        public string TeacherName { get; set; }

        [Required(ErrorMessage = "Subject is required.")]
        public string Subject { get; set; }

        public string? PhotoPath { get; set; }

        [NotMapped]
        public IFormFile? Photo { get; set; }

        public bool Status { get; set; } = true;
    }

}
