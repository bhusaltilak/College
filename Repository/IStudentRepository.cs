using COLLEGE.Models.ViewModels;

namespace COLLEGE.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<DetailsViewModel>> GetAllAsync();
        Task<DetailsViewModel> GetByIdAsync(int id);
        Task AddAsync(DetailsViewModel model);
        Task<bool> UpdateAsync(DetailsViewModel model);
        Task<bool> DeleteAsync(int id);


    }
}
