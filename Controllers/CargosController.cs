using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistrodeEmpleado.Data;
using RegistrodeEmpleado.Models;

namespace RegistrodeEmpleado.Controllers
{
    public class CargosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CargosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cargos
        public async Task<IActionResult> Index()
        {
              return _context.cargos != null ? 
                          View(await _context.cargos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.cargos'  is null.");
        }

        // GET: Cargos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cargos == null)
            {
                return NotFound();
            }

            var cargos = await _context.cargos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargos == null)
            {
                return NotFound();
            }

            return View(cargos);
        }

        // GET: Cargos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cargos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Salario")] Cargos cargos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cargos);
        }

        // GET: Cargos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cargos == null)
            {
                return NotFound();
            }

            var cargos = await _context.cargos.FindAsync(id);
            if (cargos == null)
            {
                return NotFound();
            }
            return View(cargos);
        }

        // POST: Cargos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Salario")] Cargos cargos)
        {
            if (id != cargos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargosExists(cargos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cargos);
        }

        // GET: Cargos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cargos == null)
            {
                return NotFound();
            }

            var cargos = await _context.cargos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cargos == null)
            {
                return NotFound();
            }

            return View(cargos);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cargos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.cargos'  is null.");
            }
            var cargos = await _context.cargos.FindAsync(id);
            if (cargos != null)
            {
                _context.cargos.Remove(cargos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CargosExists(int id)
        {
          return (_context.cargos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
