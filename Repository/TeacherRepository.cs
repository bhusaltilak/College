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


        public async Task<IEnumerable<DetailsViewModel>> GetAllAsync()
        {
            return await _context.Teachers
                .Where(t=>t.Status==true)
            .Select(t => new DetailsViewModel
            {
                TeacherId = t.TeacherId,
                TeacherName = t.TeacherName,
                Subject = t.Subject,
                Status = true,
               
            })
            .ToListAsync();
        }

        public async Task<DetailsViewModel> GetByIdAsync(int id)
        {

            return await _context.Teachers
                .Where(t => t.TeacherId == id && t.Status == true)
                .Select(t => new DetailsViewModel
                {
                    TeacherId = t.TeacherId,
                    TeacherName = t.TeacherName,
                    Subject = t.Subject,
                    Status = t.Status,
                  
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CreateAsync(DetailsViewModel model)
        {
            var teacher = new Teacher
            {
                TeacherName = model.TeacherName,
                Subject = model.Subject,
                Status = true,
               
            };
            _context.Teachers.Add(teacher);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(DetailsViewModel model)
        {
            var teacher = await _context.Teachers.FindAsync(model.TeacherId);
            if (teacher == null || teacher.Status==false) return false;

            teacher.TeacherName = model.TeacherName;
            teacher.Subject = model.Subject;
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
