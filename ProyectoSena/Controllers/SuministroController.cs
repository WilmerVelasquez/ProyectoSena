using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoSena.Core;
using ProyectoSena.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSena.Controllers
{
    public class SuministroController : Controller
    {
        private readonly ProyectoSenaDbContext _context;

        public SuministroController(ProyectoSenaDbContext context)
        {
            _context = context;
        }
        // GET: Suministroes
        public async Task<IActionResult> Index()
        {
            var sistemaRecursosHumanosDbContext = _context.Suministro.Include(s => s.IdSolicitud);
            return View(await sistemaRecursosHumanosDbContext.ToListAsync());
        }

        // GET: Suministroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suministro = await _context.Suministro
                .Include(s => s.IdSolicitud)
                .FirstOrDefaultAsync(m => m.IdSuministro == id);
            if (suministro == null)
            {
                return NotFound();
            }

            return View(suministro);
        }

        // GET: Suministroes/Create
        public IActionResult Create()
        {
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitud, "IdSolicitud", "IdSolicitud");
            return View();
        }

        // POST: Suministroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSuministro,NombreSuministro,IdSolicitud")] Suministro suministro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suministro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitud, "IdSolicitud", "IdSolicitud", suministro.IdSolicitud);
            return View(suministro);
        }

        // GET: Suministroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suministro = await _context.Suministro.FindAsync(id);
            if (suministro == null)
            {
                return NotFound();
            }
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitud, "IdSolicitud", "IdSolicitud", suministro.IdSolicitud);
            return View(suministro);
        }

        // POST: Suministroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSuministro,NombreSuministro,IdSolicitud")] Suministro suministro)
        {
            if (id != suministro.IdSuministro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suministro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuministroExists(suministro.IdSuministro))
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
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitud, "IdSolicitud", "IdSolicitud", suministro.IdSolicitud);
            return View(suministro);
        }

        // GET: Suministroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suministro = await _context.Suministro
                .Include(s => s.IdSolicitud)
                .FirstOrDefaultAsync(m => m.IdSuministro == id);
            if (suministro == null)
            {
                return NotFound();
            }

            return View(suministro);
        }

        // POST: Suministroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suministro = await _context.Suministro.FindAsync(id);
            _context.Suministro.Remove(suministro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuministroExists(int id)
        {
            return _context.Suministro.Any(e => e.IdSuministro == id);
        }
    }
}
