using COLLEGE.Data;
using COLLEGE.Models.DbEntities;
using COLLEGE.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace COLLEGE.Repository
{
    public class StudentFeeRepository : IStudentFeeRepository
    {
        private readonly CollegeDbContext _context;

        public StudentFeeRepository(CollegeDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentFeeViewModel>> GetAllAsync()
        {
            return await _context.StudentFees
                .Where(f => f.Status == true)
                .Select(f => new StudentFeeViewModel
                {
                    Id = f.Id,
                    StudentName = f.StudentName,
                    Grade = f.Grade,
                    Month = f.Month,
                    Amount = f.Amount,
                    AmountStatus = f.AmountStatus
                }).ToListAsync();
        }

        public async Task<StudentFeeViewModel> GetByIdAsync(int id)
        {
            var fee = await _context.StudentFees
                .Where(f => f.Id == id && f.Status == true)
                .Select(f => new StudentFeeViewModel {
                    Id = f.Id,
                   
                    StudentName = f.StudentName,
                    Grade = f.Grade,
                    Month = f.Month,
                    Amount = f.Amount,
                    AmountStatus = f.AmountStatus

                }).FirstOrDefaultAsync();
            return fee;
        }


        public async Task<bool> CreateAsync(StudentFeeViewModel model)
        {
            var entity = new StudentFee
            {
                StudentName = model.StudentName,
                Grade = model.Grade,
                Month = model.Month,
                Amount = model.Amount,
                AmountStatus = model.AmountStatus,
                Status = true
            };

            _context.StudentFees.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(StudentFeeViewModel model)
        {
            var entity = await _context.StudentFees.FirstOrDefaultAsync(f => f.Id == model.Id && f.Status == true);
            if (entity == null) return false;


            entity.StudentName = model.StudentName;
            entity.Grade = model.Grade;
            entity.Month = model.Month;
            entity.Amount = model.Amount;
            entity.AmountStatus = model.AmountStatus;

            _context.StudentFees.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var fee = await _context.StudentFees.FirstOrDefaultAsync(f => f.Id == id && f.Status == true);
            if (fee == null) return false;

            fee.Status = false;
            _context.StudentFees.Update(fee);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
