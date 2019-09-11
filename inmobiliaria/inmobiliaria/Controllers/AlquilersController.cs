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
    public class AlquilersController : Controller
    {
        private readonly MyDbContext _context;

        public AlquilersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Alquilers
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Alquiler.Include(a => a.Inmueble).Include(a => a.Inquilino);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Alquilers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquiler
                .Include(a => a.Inmueble)
                .Include(a => a.Inquilino)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // GET: Alquilers/Create
        public IActionResult Create()
        {
            ViewData["InmuebleId"] = new SelectList(_context.Inmueble, "Id", "Id");
            ViewData["InquilinoId"] = new SelectList(_context.Inquilino, "Id", "Id");
            return View();
        }

        // POST: Alquilers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,InmuebleId,InquilinoId,Nombre,FechaAlta,FechaBaja,Monto")] Alquiler alquiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alquiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InmuebleId"] = new SelectList(_context.Inmueble, "Id", "Id", alquiler.InmuebleId);
            ViewData["InquilinoId"] = new SelectList(_context.Inquilino, "Id", "Id", alquiler.InquilinoId);
            return View(alquiler);
        }

        // GET: Alquilers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquiler.FindAsync(id);
            if (alquiler == null)
            {
                return NotFound();
            }
            ViewData["InmuebleId"] = new SelectList(_context.Inmueble, "Id", "Id", alquiler.InmuebleId);
            ViewData["InquilinoId"] = new SelectList(_context.Inquilino, "Id", "Id", alquiler.InquilinoId);
            return View(alquiler);
        }

        // POST: Alquilers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,InmuebleId,InquilinoId,Nombre,FechaAlta,FechaBaja,Monto")] Alquiler alquiler)
        {
            if (id != alquiler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alquiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlquilerExists(alquiler.Id))
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
            ViewData["InmuebleId"] = new SelectList(_context.Inmueble, "Id", "Id", alquiler.InmuebleId);
            ViewData["InquilinoId"] = new SelectList(_context.Inquilino, "Id", "Id", alquiler.InquilinoId);
            return View(alquiler);
        }

        // GET: Alquilers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquiler
                .Include(a => a.Inmueble)
                .Include(a => a.Inquilino)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // POST: Alquilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alquiler = await _context.Alquiler.FindAsync(id);
            _context.Alquiler.Remove(alquiler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlquilerExists(int id)
        {
            return _context.Alquiler.Any(e => e.Id == id);
        }
    }
}
