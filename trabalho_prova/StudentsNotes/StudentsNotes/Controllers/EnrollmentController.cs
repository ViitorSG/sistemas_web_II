using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentsNotes.Data;
using StudentsNotes.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentsNotes.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly StudentsNotesContext _context;

        public EnrollmentController(StudentsNotesContext context)
        {
            _context = context;
        }

        // GET: Enrollment
        public async Task<IActionResult> Index()
        {
            var enrollments = await _context.Enrollments
                .OrderBy(e => e.EnrollmentYear)
                .Include(s => s.Student)
                .ToListAsync();

            return View(enrollments);
        }

        // GET: Enrollment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(s => s.Student)
                .FirstOrDefaultAsync(e => e.EnrollmentID == id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollment/Create
        public IActionResult Create()
        {
            var alunos = _context.Students.OrderBy(s => s.StudentName).ToList();
            alunos.Insert(0, new Student()
            {
                StudentID = 0,
                StudentName = "Selecione o Aluno",
                StudentAge = 0,
                Email = "",
                Telefone = "",
                HasNotebook = false,
            });
            ViewBag.StudentID = new SelectList(alunos, "StudentID", "StudentName");

            return View();
        }

        // POST: Enrollment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Enrollment enrollment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(enrollment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("Error", "Unable to save changes.");
            }

            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "StudentName");
            return View(enrollment);
        }

        // GET: Enrollment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FindAsync(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            var alunos = _context.Students.OrderBy(s => s.StudentName).ToList();
            alunos.Insert(0, new Student()
            {
                StudentID = 0,
                StudentName = "Selecione o Aluno",
                StudentAge = 0,
                Email = "",
                Telefone = "",
                HasNotebook = false,
            });
            ViewBag.StudentID = new SelectList(alunos, "StudentID", "StudentName");

            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Enrollment enrollment)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!EnrollmentExists(enrollment.EnrollmentID))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(s => s.Student)
                .SingleOrDefaultAsync(i => i.EnrollmentID == id);

            if (enrollment == null)
            {
                return NotFound();
            }

            TempData["AlertMessage"] = "Record deleted successfully!";

            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            _context.Enrollments.Remove(enrollment!);
            TempData["AlertMessage"] = "Record deleted successfully!";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollments.Any(e => e.EnrollmentID == id);
        }
    }
}
