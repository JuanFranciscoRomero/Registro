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
    public class EmpleadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.empleados.Include(e => e.Beneficios).Include(e => e.Cargo).Include(e => e.Habilidades).Include(e => e.Proyectos);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.empleados
                .Include(e => e.Beneficios)
                .Include(e => e.Cargo)
                .Include(e => e.Habilidades)
                .Include(e => e.Proyectos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["BeneficiosId"] = new SelectList(_context.beneficios, "Id", "Id");
            ViewData["CargosId"] = new SelectList(_context.cargos, "Id", "Id");
            ViewData["HabilidadesId"] = new SelectList(_context.habilidades, "Id", "Id");
            ViewData["ProyectosId"] = new SelectList(_context.proyectos, "Id", "Id");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombres,Apellidos,FechadeNacimiento,FechadeRegistro,BeneficiosId,CargosId,HabilidadesId,ProyectosId")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeneficiosId"] = new SelectList(_context.beneficios, "Id", "Id", empleado.BeneficiosId);
            ViewData["CargosId"] = new SelectList(_context.cargos, "Id", "Id", empleado.CargosId);
            ViewData["HabilidadesId"] = new SelectList(_context.habilidades, "Id", "Id", empleado.HabilidadesId);
            ViewData["ProyectosId"] = new SelectList(_context.proyectos, "Id", "Id", empleado.ProyectosId);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["BeneficiosId"] = new SelectList(_context.beneficios, "Id", "Id", empleado.BeneficiosId);
            ViewData["CargosId"] = new SelectList(_context.cargos, "Id", "Id", empleado.CargosId);
            ViewData["HabilidadesId"] = new SelectList(_context.habilidades, "Id", "Id", empleado.HabilidadesId);
            ViewData["ProyectosId"] = new SelectList(_context.proyectos, "Id", "Id", empleado.ProyectosId);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombres,Apellidos,FechadeNacimiento,FechadeRegistro,BeneficiosId,CargosId,HabilidadesId,ProyectosId")] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id))
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
            ViewData["BeneficiosId"] = new SelectList(_context.beneficios, "Id", "Id", empleado.BeneficiosId);
            ViewData["CargosId"] = new SelectList(_context.cargos, "Id", "Id", empleado.CargosId);
            ViewData["HabilidadesId"] = new SelectList(_context.habilidades, "Id", "Id", empleado.HabilidadesId);
            ViewData["ProyectosId"] = new SelectList(_context.proyectos, "Id", "Id", empleado.ProyectosId);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.empleados
                .Include(e => e.Beneficios)
                .Include(e => e.Cargo)
                .Include(e => e.Habilidades)
                .Include(e => e.Proyectos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.empleados == null)
            {
                return Problem("Entity set 'ApplicationDbContext.empleados'  is null.");
            }
            var empleado = await _context.empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.empleados.Remove(empleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
          return (_context.empleados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
