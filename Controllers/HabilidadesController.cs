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
    public class HabilidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HabilidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Habilidades
        public async Task<IActionResult> Index()
        {
              return _context.habilidades != null ? 
                          View(await _context.habilidades.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.habilidades'  is null.");
        }

        // GET: Habilidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.habilidades == null)
            {
                return NotFound();
            }

            var habilidades = await _context.habilidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habilidades == null)
            {
                return NotFound();
            }

            return View(habilidades);
        }

        // GET: Habilidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habilidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] Habilidades habilidades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habilidades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habilidades);
        }

        // GET: Habilidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.habilidades == null)
            {
                return NotFound();
            }

            var habilidades = await _context.habilidades.FindAsync(id);
            if (habilidades == null)
            {
                return NotFound();
            }
            return View(habilidades);
        }

        // POST: Habilidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] Habilidades habilidades)
        {
            if (id != habilidades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habilidades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabilidadesExists(habilidades.Id))
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
            return View(habilidades);
        }

        // GET: Habilidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.habilidades == null)
            {
                return NotFound();
            }

            var habilidades = await _context.habilidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habilidades == null)
            {
                return NotFound();
            }

            return View(habilidades);
        }

        // POST: Habilidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.habilidades == null)
            {
                return Problem("Entity set 'ApplicationDbContext.habilidades'  is null.");
            }
            var habilidades = await _context.habilidades.FindAsync(id);
            if (habilidades != null)
            {
                _context.habilidades.Remove(habilidades);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabilidadesExists(int id)
        {
          return (_context.habilidades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
