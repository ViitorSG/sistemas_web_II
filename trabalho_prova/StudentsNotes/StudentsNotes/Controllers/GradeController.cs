using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsNotes.Data;
using StudentsNotes.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsNotes.Controllers
{
    public class GradeController : Controller
    {
        private readonly StudentsNotesContext _context;

        public GradeController(StudentsNotesContext context)
        {
            _context = context;
        }

        // GET: GradeController
        public async Task<IActionResult> Index()
        {
            var grades = await _context.grades
                .Include(g => g.Student)
                .Include(g => g.Discipline)  
                .OrderBy(g => g.GradeID)
                .ToListAsync();

            return View(grades);
        }

        // GET: GradeController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.grades
                                .Include(g => g.Student)
                .Include(g => g.Discipline)
                .FirstOrDefaultAsync(m => m.GradeID == id);

            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // GET: GradeController/Create
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
            ViewBag.Alunos = new SelectList(alunos, "StudentID", "StudentName");

            var disciplinas = _context.Disciplines.OrderBy(d => d.DisciplineName).ToList();
            disciplinas.Insert(0, new Discipline()
            {
                DisciplineID = 0,
                DisciplineName = "Selecione a Disciplina",
                Workload = 0,
                Professor = "",

            });
            ViewBag.Disciplinas = new SelectList(disciplinas, "DisciplineID", "DisciplineName");

            return View();
        }

        // POST: GradeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Grade grade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(grade);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("Erro", "Não foi possível inserir os dados.");
            }
            return View(grade);
        }

        // GET: GradeController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.grades.FindAsync(id);

            if (grade == null)
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
            ViewBag.Alunos = new SelectList(alunos, "StudentID", "StudentName");

            var disciplinas = _context.Disciplines.OrderBy(d => d.DisciplineName).ToList();
            disciplinas.Insert(0, new Discipline()
            {
                DisciplineID = 0,
                DisciplineName = "Selecione a Disciplina",
                Workload = 0,
                Professor = "",

            });
            ViewBag.Disciplinas = new SelectList(disciplinas, "DisciplineID", "DisciplineName");

            return View(grade);
        }

        // POST: GradeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Grade grade)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!GradeExists(grade.GradeID))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(grade);
        }

        // GET: GradeController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = await _context.grades
                .Include(g => g.Student)
                .Include(g => g.Discipline)
                .SingleOrDefaultAsync(i => i.GradeID == id);

            if (grade == null)
            {
                return NotFound();
            }

            TempData["AlertMessage"] = "Registro excluído com sucesso!";


            return View(grade);
        }

        // POST: GradeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var grade = await _context.grades.FindAsync(id);
            _context.grades.Remove(grade!);
            TempData["AlertMessage"] = "Registro excluído com sucesso!";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradeExists(int id)
        {
            return _context.grades.Any(e => e.GradeID == id);
        }
    }
}
