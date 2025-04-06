using COLLEGE.Models.ViewModels;

namespace COLLEGE.Repository
{
    public interface IStudentFeeRepository
    {
        Task<List<StudentFeeViewModel>> GetAllAsync();
     Task<StudentFeeViewModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(StudentFeeViewModel model);
        Task<bool> UpdateAsync(StudentFeeViewModel model);
        Task<bool> DeleteAsync(int id);

    }
}
