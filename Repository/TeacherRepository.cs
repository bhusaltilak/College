using COLLEGE.Data;
using COLLEGE.Models.DbEntities;
using COLLEGE.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace COLLEGE.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly CollegeDbContext _context;

        public TeacherRepository(CollegeDbContext context)
        {
            _context = context;
        }


<<<<<<< HEAD
        public async Task<IEnumerable<TeacherViewModel>> GetAllAsync()
        {
            return await _context.Teachers
                .Where(t=>t.Status==true)
            .Select(t => new TeacherViewModel
=======
        public async Task<IEnumerable<DetailsViewModel>> GetAllAsync()
        {
            return await _context.Teachers
                .Where(t=>t.Status==true)
            .Select(t => new DetailsViewModel
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
            {
                TeacherId = t.TeacherId,
                TeacherName = t.TeacherName,
                Subject = t.Subject,
<<<<<<< HEAD
                PhotoPath = t.PhotoPath,
=======
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
                Status = true,
               
            })
            .ToListAsync();
        }

<<<<<<< HEAD
        public async Task<TeacherViewModel> GetByIdAsync(int id)
=======
        public async Task<DetailsViewModel> GetByIdAsync(int id)
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
        {

            return await _context.Teachers
                .Where(t => t.TeacherId == id && t.Status == true)
<<<<<<< HEAD
                .Select(t => new TeacherViewModel
=======
                .Select(t => new DetailsViewModel
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
                {
                    TeacherId = t.TeacherId,
                    TeacherName = t.TeacherName,
                    Subject = t.Subject,
<<<<<<< HEAD
                    PhotoPath = t.PhotoPath,
=======
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
                    Status = t.Status,
                  
                })
                .FirstOrDefaultAsync();
        }

<<<<<<< HEAD
        public async Task<bool> CreateAsync(TeacherViewModel model)
        {
            Console.WriteLine("🛠 CreateAsync() called");

=======
        public async Task<bool> CreateAsync(DetailsViewModel model)
        {
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
            var teacher = new Teacher
            {
                TeacherName = model.TeacherName,
                Subject = model.Subject,
<<<<<<< HEAD
                PhotoPath = model.PhotoPath,
                Status = true
            };

            _context.Teachers.Add(teacher);
            var result = await _context.SaveChangesAsync();
            Console.WriteLine("✅ Save result: " + result);
            return result > 0;
        }

        public async Task<bool> UpdateAsync(TeacherViewModel model)
=======
                Status = true,
               
            };
            _context.Teachers.Add(teacher);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(DetailsViewModel model)
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
        {
            var teacher = await _context.Teachers.FindAsync(model.TeacherId);
            if (teacher == null || teacher.Status==false) return false;

            teacher.TeacherName = model.TeacherName;
            teacher.Subject = model.Subject;
<<<<<<< HEAD
            teacher.PhotoPath = model.PhotoPath;
=======
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
            teacher.Status = true;

            _context.Teachers.Update(teacher);
            return await _context.SaveChangesAsync() > 0;
        }

       public async Task<bool> DeleteAsync(int id)
        {


            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null) return false;

            teacher.Status = false;
            _context.Teachers.Update(teacher);
            return await _context.SaveChangesAsync() > 0;
        }

            


    }
}
