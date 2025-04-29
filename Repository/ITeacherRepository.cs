using COLLEGE.Models.DbEntities;
using COLLEGE.Models.ViewModels;


namespace COLLEGE.Repository
{
    public interface ITeacherRepository
    {
<<<<<<< HEAD
        Task<IEnumerable<TeacherViewModel>> GetAllAsync();
        Task<TeacherViewModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(TeacherViewModel model);
        Task<bool> UpdateAsync(TeacherViewModel model);
=======
        Task<IEnumerable<DetailsViewModel>> GetAllAsync();
        Task<DetailsViewModel> GetByIdAsync(int id);
        Task<bool> CreateAsync(DetailsViewModel model);
        Task<bool> UpdateAsync(DetailsViewModel model);
>>>>>>> 5572f4de444e80214a0e803bd53aa8e9f592e0f5
        Task<bool> DeleteAsync(int id);
    }
}
