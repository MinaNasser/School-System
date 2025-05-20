using Microsoft.AspNetCore.Mvc;
using School.DTOs;
using School.Entities;
using School.Services.Interfaces;
using System.Threading.Tasks;

namespace School.Presentation.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        // GET: Subject
        public async Task<IActionResult> Index()
        {
            var subjects = await _subjectService.GetAllAsync();
            return View(subjects);
        }

        // GET: Subject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubjectDTO subject)
        {
            if (!ModelState.IsValid)
                return View(subject);

            await _subjectService.AddAsync(subject);
            return RedirectToAction(nameof(Index));
        }

        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var subject = await _subjectService.GetByIdAsync(id);
            if (subject == null)
                return NotFound();

            return View(subject);
        }

        // POST: Subject/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubjectDTO subject)
        {
            if (!ModelState.IsValid)
                return View(subject);

            await _subjectService.UpdateAsync(subject);
            return RedirectToAction(nameof(Index));
        }

        // GET: Subject/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var subject = await _subjectService.GetByIdAsync(id);
            if (subject == null)
                return NotFound();

            return View(subject);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _subjectService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
