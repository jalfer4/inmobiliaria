using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using inmobiliariaMVC.Models;

namespace inmobiliaria.Controllers
{
    public class GarantesController : Controller
    {
        private readonly MyDbContext _context;

        public GarantesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Garantes
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Garante.Include(g => g.Alquiler);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Garantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garante = await _context.Garante
                .Include(g => g.Alquiler)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garante == null)
            {
                return NotFound();
            }

            return View(garante);
        }

        // GET: Garantes/Create
        public IActionResult Create()
        {
            ViewData["AlquilerId"] = new SelectList(_context.Alquiler, "Id", "Id");
            return View();
        }

        // POST: Garantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlquilerId,Nombre,Apellido,Trabajo,Dni,Telefono,Email,FechaAlta,EstaHabilitado,EstaPublicado")] Garante garante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlquilerId"] = new SelectList(_context.Alquiler, "Id", "Id", garante.AlquilerId);
            return View(garante);
        }

        // GET: Garantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garante = await _context.Garante.FindAsync(id);
            if (garante == null)
            {
                return NotFound();
            }
            ViewData["AlquilerId"] = new SelectList(_context.Alquiler, "Id", "Id", garante.AlquilerId);
            return View(garante);
        }

        // POST: Garantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AlquilerId,Nombre,Apellido,Trabajo,Dni,Telefono,Email,FechaAlta,EstaHabilitado,EstaPublicado")] Garante garante)
        {
            if (id != garante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GaranteExists(garante.Id))
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
            ViewData["AlquilerId"] = new SelectList(_context.Alquiler, "Id", "Id", garante.AlquilerId);
            return View(garante);
        }

        // GET: Garantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garante = await _context.Garante
                .Include(g => g.Alquiler)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garante == null)
            {
                return NotFound();
            }

            return View(garante);
        }

        // POST: Garantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var garante = await _context.Garante.FindAsync(id);
            _context.Garante.Remove(garante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GaranteExists(int id)
        {
            return _context.Garante.Any(e => e.Id == id);
        }
    }
}
