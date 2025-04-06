using COLLEGE.Models.DbEntities;
using COLLEGE.Models.ViewModels;


namespace COLLEGE.Repository
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<DetailsViewModel>> GetAllAsync();
        Task<DetailsViewModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(DetailsViewModel model);
        Task<bool> UpdateAsync(DetailsViewModel model);
        Task<bool> DeleteAsync(int id);
    }
}
