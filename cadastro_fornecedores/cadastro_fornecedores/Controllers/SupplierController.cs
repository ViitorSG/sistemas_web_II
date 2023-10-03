using cadastro_fornecedores.Data;
using cadastro_fornecedores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cadastro_fornecedores.Controllers
{
    public class SupplierController : Controller
    {
        private readonly Context _context;

        public SupplierController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allSuppliers = _context.Suppliers.ToList();
            return View(allSuppliers);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.id == id);

            if(supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplier);
                TempData["AlertMessage"] = "Fornecedor adicionado com sucesso!";
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.id == id);
            if (supplier == null)
            {
                return NotFound();
            }
            TempData["AlertMessage"] = "Registro excluído com sucesso!";

            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            _context.Suppliers.Remove(supplier);
            TempData["AlertMessage"] = "Registro excluído com sucesso!";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return BadRequest();
            }
            TempData["AlertMessage"] = "Fornecedor Editado com sucesso!";
            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(
            int? id,
            Supplier supplier)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

    }
}
