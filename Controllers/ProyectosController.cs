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
    public class ProyectosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProyectosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Proyectos
        public async Task<IActionResult> Index()
        {
              return _context.proyectos != null ? 
                          View(await _context.proyectos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.proyectos'  is null.");
        }

        // GET: Proyectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.proyectos == null)
            {
                return NotFound();
            }

            var proyectos = await _context.proyectos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyectos == null)
            {
                return NotFound();
            }

            return View(proyectos);
        }

        // GET: Proyectos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proyectos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] Proyectos proyectos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proyectos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proyectos);
        }

        // GET: Proyectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.proyectos == null)
            {
                return NotFound();
            }

            var proyectos = await _context.proyectos.FindAsync(id);
            if (proyectos == null)
            {
                return NotFound();
            }
            return View(proyectos);
        }

        // POST: Proyectos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion")] Proyectos proyectos)
        {
            if (id != proyectos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proyectos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProyectosExists(proyectos.Id))
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
            return View(proyectos);
        }

        // GET: Proyectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.proyectos == null)
            {
                return NotFound();
            }

            var proyectos = await _context.proyectos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proyectos == null)
            {
                return NotFound();
            }

            return View(proyectos);
        }

        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.proyectos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.proyectos'  is null.");
            }
            var proyectos = await _context.proyectos.FindAsync(id);
            if (proyectos != null)
            {
                _context.proyectos.Remove(proyectos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyectosExists(int id)
        {
          return (_context.proyectos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
