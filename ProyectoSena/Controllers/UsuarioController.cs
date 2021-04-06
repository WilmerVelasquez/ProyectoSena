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
    public class UsuarioController : Controller
    {
        private readonly ProyectoSenaDbContext _context;

        public UsuarioController(ProyectoSenaDbContext context)
        {
            _context = context;
        }
        // GET: Suministroes
        public async Task<IActionResult> Index()
        {
            var ProyectoSenaDbContext = _context.Usuario.Include(s => s.IdSolicitudNavigation).Include(s =>s.IdEstadoNavigation).Include(s =>s.IdHorarioNavigation);
            return View(await ProyectoSenaDbContext.ToListAsync());
        }

        // GET: Suministroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(s => s.IdSolicitudNavigation)
                .Include(s => s.IdEstadoNavigation)
                .Include(s => s.IdHorarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Suministroes/Create
        public IActionResult Create()
        {
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitud, "IdSolicitud", "IdSolicitud");
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "IdEstado");
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "IdHorario");
            return View();
        }

        // POST: Suministroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Direccion")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitud, "IdSolicitud", "IdSolicitud");
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "IdEstado");
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "IdHorario");
            return View(usuario);
        }

        // GET: Suministroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitud, "IdSolicitud", "IdSolicitud");
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "IdEstado");
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "IdHorario");
            return View(usuario);
        }

        // POST: Suministroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Direccion")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuministroExists(usuario.IdUsuario))
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
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitud, "IdSolicitud", "IdSolicitud");
            ViewData["IdEstado"] = new SelectList(_context.Estado, "IdEstado", "IdEstado");
            ViewData["IdHorario"] = new SelectList(_context.Horarios, "IdHorario", "IdHorario");
            return View(usuario);
        }

        // GET: Suministroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(s => s.IdSolicitudNavigation)
                .Include(s => s.IdEstadoNavigation)
                .Include(s => s.IdHorarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Suministroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuministroExists(int id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}
