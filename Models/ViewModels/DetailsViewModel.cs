using System.ComponentModel.DataAnnotations;

namespace COLLEGE.Models.ViewModels
{
    public class DetailsViewModel
    {
        public int StudentId { get; set; }
<<<<<<< HEAD
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        
        public int Grade { get; set; }

        public int ParentId { get; set; }
        [Required]
=======

        public string StudentName { get; set; }
        public string Address { get; set; }

        public int Grade { get; set; }

        public int ParentId { get; set; }
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
        public string ParentName { get; set; }

        [Phone]
        public string Phone { get; set; }

        public IFormFile Photo { get; set; }

        public string PhotoPath { get; set; }

<<<<<<< HEAD
      
=======
        //Teacher

        public int TeacherId { get; set; }

        public string TeacherName { get; set; }
       public string Subject { get; set; }
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
        public bool Status { get; set; } = true;




    }
}
