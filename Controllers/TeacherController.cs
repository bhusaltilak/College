using COLLEGE.Models.DbEntities;
using COLLEGE.Models.ViewModels;
using COLLEGE.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace COLLEGE.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeacherController(ITeacherRepository teacherRepository, IWebHostEnvironment webHostEnvironment)
        {
            _teacherRepository = teacherRepository;
            _webHostEnvironment = webHostEnvironment;
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
                return View(new TeacherViewModel());

            var teacher = await _teacherRepository.GetByIdAsync(id.Value);
            return View(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEdit(TeacherViewModel model)
        {
           

            if (!ModelState.IsValid)
            {
               
                return View(model);
            }

            // File Upload
            if (model.Photo != null && model.Photo.Length > 0)
            {
                try
                {
                    string folder = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Teacher");
                    Directory.CreateDirectory(folder);
                    string filename = Guid.NewGuid() + "_" + model.Photo.FileName;
                    string filepath = Path.Combine(folder, filename);
                    using var fs = new FileStream(filepath, FileMode.Create);
                    await model.Photo.CopyToAsync(fs);
                    model.PhotoPath = "/Images/Teacher/" + filename;
                   
                }
                catch (Exception ex)
                {    
                    Console.WriteLine(" File Upload Error: " + ex.Message);
                }
            }

            if (model.TeacherId == 0)
            {
              
                await _teacherRepository.CreateAsync(model);
            }
            else
            {
              
                await _teacherRepository.UpdateAsync(model);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _teacherRepository.DeleteAsync(id);
            if(!result)
                return NotFound();

            TempData["Success"] = "Teacher deleted successfully!";
            return RedirectToAction("Index");
        }
    }
    
}
