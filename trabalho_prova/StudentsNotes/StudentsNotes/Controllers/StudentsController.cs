using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsNotes.Data;
using StudentsNotes.Models;
using Microsoft.Data.SqlClient;

namespace StudentsNotes.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentsNotesContext _context;

        public StudentsController(StudentsNotesContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                .OrderBy(s => s.StudentName)
                .ToListAsync();

            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                // Adiciona uma mensagem de erro genérica
                ModelState.AddModelError("Erro", "Não foi possível inserir os dados.");

                // Verifica se a exceção é devido a uma violação de chave única
                if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
                {
                    ModelState.AddModelError("StudentName", "Já existe um aluno com esse nome.");
                }
            }

            return View(student);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Student student)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!StudentExists(student.StudentID))
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        private bool StudentExists(int? id)
        {
            return _context.Students.Any(e => e.StudentID == id);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.SingleOrDefaultAsync(i => i.StudentID == id);

            if (student == null)
            {
                return NotFound();
            }

            TempData["AlertMessage"] = "Registro excluído com sucesso!";

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student!);
            TempData["AlertMessage"] = "Registro excluído com sucesso!";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
