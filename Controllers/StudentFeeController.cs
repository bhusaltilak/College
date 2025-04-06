using COLLEGE.Models.ViewModels;
using COLLEGE.Repository;
using Microsoft.AspNetCore.Mvc;

namespace COLLEGE.Controllers
{
    public class StudentFeeController : Controller
    {
        private readonly IStudentFeeRepository _repository;

        public StudentFeeController(IStudentFeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _repository.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var fee = await _repository.GetByIdAsync(id);

            if (fee == null)
                return NotFound();

            return View(fee);
        }
        [HttpGet]
        public async Task<IActionResult> CreateEdit(int Id)
        {
            var existingFee = await _repository.GetByIdAsync(Id);

            var model = new StudentFeeFormViewModel
            {
                Fees = existingFee != null
                    ? new List<StudentFeeViewModel> { existingFee }
                    : new List<StudentFeeViewModel> { new StudentFeeViewModel() }
            };


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEdit(StudentFeeFormViewModel model)
        {
            if (!ModelState.IsValid || model.Fees == null || !model.Fees.Any())
            {
                ModelState.AddModelError("", "Please enter at least one fee entry.");
                return View(model);
            }

            foreach (var fee in model.Fees)
            {
                if (fee.Id == 0)
                    await _repository.CreateAsync(fee);
                else
                    await _repository.UpdateAsync(fee);
            }

            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

    }
}
