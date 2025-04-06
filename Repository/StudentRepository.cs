using COLLEGE.Data;
using COLLEGE.Models.DbEntities;
using COLLEGE.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace COLLEGE.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CollegeDbContext _context;

        public StudentRepository(CollegeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetailsViewModel>> GetAllAsync()
        {
            return await _context.Students
               .Include(s => s.Parent)
                .Where(s => s.Status == true && s.Parent.Status == true)
               .Select(s => new DetailsViewModel
               {
                   StudentId = s.StudentId,
                   StudentName = s.StudentName,
                   Grade = s.Grade,
                   Address = s.Address,
                   PhotoPath = s.PhotoPath,
                   ParentId = s.Parent.ParentId,
                   ParentName = s.Parent.ParentName,
                   Phone = s.Parent.Phone
               })
               .ToListAsync();
        }




        public async Task<DetailsViewModel> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(s => s.Parent)
                .Where(s => s.StudentId == id && s.Status==true)
                .Select(s => new DetailsViewModel
                {
                    StudentId = s.StudentId,
                    StudentName = s.StudentName,
                    Address = s.Address,
                    Grade = s.Grade,
                    PhotoPath = s.PhotoPath,
                    ParentId = s.Parent.ParentId,
                    ParentName = s.Parent.ParentName,
                    Phone = s.Parent.Phone
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(DetailsViewModel model)
        {
            var parent = new Parent
            {
                ParentName = model.ParentName,
                Phone = model.Phone,
                Status = true,
            };
            _context.Parents.Add(parent);
            await _context.SaveChangesAsync();

            var student = new Student
            {
                StudentName = model.StudentName,
                Address = model.Address,
                Grade = model.Grade,
                PhotoPath = model.PhotoPath,
                ParentId = parent.ParentId,
                Status = true,
            };
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(DetailsViewModel model)
        {
            var student = await _context.Students
                .Include(s => s.Parent)
                .FirstOrDefaultAsync(s => s.StudentId == model.StudentId);

            if (student == null || student.Status==false) return false;

            // Update student
            student.StudentName = model.StudentName;
            student.Address = model.Address;
            student.Grade = model.Grade;

            // Update parent
            if (student.Parent != null)
            {
                student.Parent.ParentName = model.ParentName;
                student.Parent.Phone = model.Phone;
            }

            _context.Students.Update(student);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students
      .Include(s => s.Parent) 
      .FirstOrDefaultAsync(s => s.StudentId == id);
          if (student == null) return false;

            student.Status = false;
            _context.Students.Update(student);

            if (student.Parent != null && student.Parent.Status)
            {
                student.Parent.Status = false;
                _context.Parents.Update(student.Parent);
            }


            return await _context.SaveChangesAsync() > 0;
        }
    }



}
