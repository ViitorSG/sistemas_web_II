using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using StudentsNotes.Models;
using StudentsNotes.Data;

namespace StudentsNotes.Controllers
{
    public class DisciplineController : Controller
    {
        private readonly StudentsNotesContext _context;

        public DisciplineController(StudentsNotesContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var disciplines = await _context.Disciplines
                .OrderBy(d => d.DisciplineName)
                .ToListAsync();

            return View(disciplines);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Discipline discipline)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(discipline);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("Erro", "Não foi possível inserir os dados.");
            }
            return View(discipline);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _context.Disciplines.FindAsync(id);

            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Discipline discipline)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discipline);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!DisciplineExists(discipline.DisciplineID))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(discipline);
        }

        private bool DisciplineExists(int id)
        {
            return _context.Disciplines.Any(e => e.DisciplineID == id);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _context.Disciplines
                .FirstOrDefaultAsync(m => m.DisciplineID == id);

            if (discipline == null)
            {
                return NotFound();
            }

            return View(discipline);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discipline = await _context.Disciplines.SingleOrDefaultAsync(i => i.DisciplineID == id);

            if (discipline == null)
            {
                return NotFound();
            }

            TempData["AlertMessage"] = "Registro excluído com sucesso!";

            return View(discipline);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var discipline = await _context.Disciplines.FindAsync(id);
            _context.Disciplines.Remove(discipline!);
            TempData["AlertMessage"] = "Registro excluído com sucesso!";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
