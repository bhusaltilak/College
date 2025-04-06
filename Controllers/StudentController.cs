using COLLEGE.Repository;
using Microsoft.AspNetCore.Mvc;
using COLLEGE.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;


namespace COLLEGE.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StudentController(IStudentRepository studentRepository , IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            _webHostEnvironment = webHostEnvironment;
        }




        public async Task <IActionResult> ListPartial()
        {
            var students = await _studentRepository.GetAllAsync();
            return View("ListPartial", students);
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetAllAsync();
            return View(students);
        }

        public async Task<IActionResult>Details(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return View(student);
        }


        public async Task<IActionResult> CreateEdit(int? id)
        {
            if (id == null || id == 0)
                return View(new DetailsViewModel());

            var model = await _studentRepository.GetByIdAsync(id.Value);
            if (model == null) return NotFound();

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(DetailsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                if (model.Photo != null && model.Photo.Length > 0)
                {
                    string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images", "Students");

                    if (!Directory.Exists(uploadFolder))
                        Directory.CreateDirectory(uploadFolder);

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo.FileName);
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Photo.CopyToAsync(stream);
                    }

                  
                    model.PhotoPath = "/Images/Students/" + uniqueFileName;

                    Console.WriteLine("✅ Assigned PhotoPath: " + model.PhotoPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ File Upload Error: " + ex.Message);
            }

            if (model.StudentId == 0)
                await _studentRepository.AddAsync(model);
            else
                await _studentRepository.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult>Delete(int id)
        {
            var result = await _studentRepository.DeleteAsync(id);
            if (!result)
                return NotFound();

           TempData["Success"] = "Student deleted successfully!"; ;
            return RedirectToAction(nameof(Index));
        }

    }
}
