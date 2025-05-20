using Microsoft.AspNetCore.Mvc;
using School.DTOs;
using School.Services.Interfaces;
using System.Threading.Tasks;

namespace School.Presentation.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;

        public StudentController(IStudentService studentService, ISubjectService subjectService)
        {
            _studentService = studentService;
            _subjectService = subjectService;
        }

        // GET: Student/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Students = await _studentService.GetAllAsync();
            ViewBag.Subjects = await _subjectService.GetAllAsync();
            return View(new StudentDTO());
        }

        // POST: Student/Index (Create)
        [HttpPost]
        public async Task<IActionResult> Index(StudentDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Subjects = await _subjectService.GetAllAsync();
                ViewBag.Students = await _studentService.GetAllAsync();
                return View(dto);
            }

            await _studentService.AddAsync(dto);
            return RedirectToAction("Index");
        }

        // GET: Student/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _studentService.GetByIdAsync(id);
            if (dto == null)
                return NotFound();

            ViewBag.Subjects = await _subjectService.GetAllAsync();
            return View(dto);
        }

        // POST: Student/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(StudentDTO dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Subjects = await _subjectService.GetAllAsync();
                return View(dto);
            }

            await _studentService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Student/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetByIdAsync(id); 
            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: Student/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
