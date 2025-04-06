using COLLEGE.Models.DbEntities;
using COLLEGE.Models.ViewModels;
using COLLEGE.Repository;
using Microsoft.AspNetCore.Mvc;

namespace COLLEGE.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }


        public async Task<IActionResult> Index()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return View(teachers);

        }

        public async Task<IActionResult> Details(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null) return NotFound();
            return View(teacher);
        }


        [HttpGet]
        public async Task<IActionResult> CreateEdit(int? id)
        {

            if (id == null || id == 0)
                return View(new DetailsViewModel());    //Create Mode

            var teacher = await _teacherRepository.GetByIdAsync(id.Value);
            if(teacher== null) 
                return NotFound(); 

            return View(teacher);  //Edit

        }

        [HttpPost]
            public async Task<IActionResult>CreateEdit(DetailsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.TeacherId == 0)
                await _teacherRepository.CreateAsync(model);
            else
                await _teacherRepository.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _teacherRepository.DeleteAsync(id);
            if(!result)
                return NotFound();

            TempData["Success"] = "Teacher deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
    
}
