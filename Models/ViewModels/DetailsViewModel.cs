using System.ComponentModel.DataAnnotations;

namespace COLLEGE.Models.ViewModels
{
    public class DetailsViewModel
    {
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        
        public int Grade { get; set; }

        public int ParentId { get; set; }
        [Required]
        public string ParentName { get; set; }

        [Phone]
        public string Phone { get; set; }

        public IFormFile Photo { get; set; }

        public string PhotoPath { get; set; }

      
        public bool Status { get; set; } = true;




    }
}
