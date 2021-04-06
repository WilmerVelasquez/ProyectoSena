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
    public class SolicitudController : Controller
    {
        private readonly ProyectoSenaDbContext _context;
        public SolicitudController(ProyectoSenaDbContext context)
        {
            _context = context;
        }

        // GET: Solicitud
        public async Task<IActionResult> Index()
        {
            var sistemaRecursosHumanosDbContext = _context.Solicitud.Include(s => s.IdEstadoNavigation).Include(s => s.IdSuministroNavigation);
            return View(await sistemaRecursosHumanosDbContext.ToListAsync());
        }

        // GET: Solicitud/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .Include(s => s.IdEstadoNavigation)
                .Include(s => s.IdSuministroNavigation)
                .FirstOrDefaultAsync(m => m.IdSolicitud == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // GET: Solicitud/Create
        public IActionResult Create()
        {
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "IdEstado");
            ViewData["IdSuministro"] = new SelectList(_context.Usuario, "IdSuministro", "IdSuministro");
            return View();
        }

        // POST: Solicitud/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSolicitud,NombreSolicitud,FechaCreada,FechaRespuesta,IdEstado,IdSuministro")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "IdEstado", solicitud.IdEstado);
            ViewData["IdSuministro"] = new SelectList(_context.Usuario, "IdSuministro", "IdSuministro", solicitud.IdSuministro);
            return View(solicitud);
        }

        // GET: Solicitud/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "IdEstado", solicitud.IdEstado);
            ViewData["IdSuministro"] = new SelectList(_context.Usuario, "IdSuministro", "IdSuministro", solicitud.IdSuministro);
            return View(solicitud);
        }

        // POST: Solicitud/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSolicitud,NombreSolicitud,FechaCreada,FechaRespuesta,IdEstado,IdSuministro")] Solicitud solicitud)
        {
            if (id != solicitud.IdSolicitud)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudExists(solicitud.IdSolicitud))
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
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "IdEstado", solicitud.IdEstado);
            ViewData["IdSuministro"] = new SelectList(_context.Usuario, "IdSuministro", "IdSuministro", solicitud.IdSuministro);
            return View(solicitud);
        }

        // GET: Solicitud/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitud
                .Include(s => s.IdEstadoNavigation)
                .Include(s => s.IdSuministroNavigation)
                .FirstOrDefaultAsync(m => m.IdSolicitud == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // POST: Solicitud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitud = await _context.Solicitud.FindAsync(id);
            _context.Solicitud.Remove(solicitud);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudExists(int id)
        {
            return _context.Solicitud.Any(e => e.IdSolicitud == id);
        }
    }
}
