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
    public class RegistroIngresoController : Controller
    {
        private readonly ProyectoSenaDbContext _context;

        public RegistroIngresoController(ProyectoSenaDbContext context)
        {
            _context = context;
        }
        // GET: RegistroIngreso
        public async Task<IActionResult> Index()
        {
            var sistemaRecursosHumanosDbContext = _context.RegistroIngreso.Include(r => r.IdHorario).Include(r => r.IdUsuario);
            return View(await sistemaRecursosHumanosDbContext.ToListAsync());
        }

        // GET: RegistroIngreso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroIngreso = await _context.RegistroIngreso
                .Include(r => r.IdHorario)
                .Include(r => r.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdRegistro == id);
            if (registroIngreso == null)
            {
                return NotFound();
            }

            return View(registroIngreso);
        }

        // GET: RegistroIngreso/Create
        public IActionResult Create()
        {
            ViewData["IdHorario"] = new SelectList(_context.Horario, "IdHorario", "IdHorario");
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: RegistroIngreso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistro,NombreRegistro,HoraEntrada,HoraSalida,IdHorario,IdUsuario")] RegistroIngreso registroIngreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroIngreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHorario"] = new SelectList(_context.Horario, "IdHorario", "IdHorario", registroIngreso.IdHorario);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", registroIngreso.IdUsuario);
            return View(registroIngreso);
        }

        // GET: RegistroIngreso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroIngreso = await _context.RegistroIngreso.FindAsync(id);
            if (registroIngreso == null)
            {
                return NotFound();
            }
            ViewData["IdHorario"] = new SelectList(_context.Horario, "IdHorario", "IdHorario", registroIngreso.IdHorario);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", registroIngreso.IdUsuario);
            return View(registroIngreso);
        }

        // POST: RegistroIngreso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistro,NombreRegistro,HoraEntrada,HoraSalida,IdHorario,IdUsuario")] RegistroIngreso registroIngreso)
        {
            if (id != registroIngreso.IdRegistro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroIngreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroIngresoExists(registroIngreso.IdRegistro))
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
            ViewData["IdHorario"] = new SelectList(_context.Horario, "IdHorario", "IdHorario", registroIngreso.IdHorario);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "IdUsuario", registroIngreso.IdUsuario);
            return View(registroIngreso);
        }

        // GET: RegistroIngreso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroIngreso = await _context.RegistroIngreso
                .Include(r => r.IdHorario)
                .Include(r => r.IdUsuario)
                .FirstOrDefaultAsync(m => m.IdRegistro == id);
            if (registroIngreso == null)
            {
                return NotFound();
            }

            return View(registroIngreso);
        }

        // POST: RegistroIngreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroIngreso = await _context.RegistroIngreso.FindAsync(id);
            _context.RegistroIngreso.Remove(registroIngreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroIngresoExists(int id)
        {
            return _context.RegistroIngreso.Any(e => e.IdRegistro == id);
        }
    }
}

