using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSena.Core;
using ProyectoSena.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSena.Controllers
{
    public class HorarioController : Controller
    {
        private readonly ProyectoSenaDbContext _context;

        public HorarioController(ProyectoSenaDbContext context)
        {
            _context = context;
        }
        //GET:Horario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Horario.ToListAsync());
        }
        //GET:Horario/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var horario = await _context.Horario
                .FirstOrDefaultAsync(m => m.IdHorario == id);
            if (horario == null)
            {
                return NotFound();
            }
            return View(horario);
        }
        //GET: Horario/Create
        public IActionResult Create()
        {
            return View();
        }
        //POST: Horario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHorario,NombreHorario")] Horario horario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(horario);
        }
        //GET: HorarioEdit
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var horario = await _context.Horario.FindAsync(id);
            if(horario == null)

            {
                return NotFound();
            }
            return View(horario);
        }
        //Post: Horario/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("IdHorario,NombreHorario")]Horario horario)
        {
            if (id != horario.IdHorario)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!HorarioExists(horario.IdHorario))
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
            return View(horario);
        }
        //GET: Horario/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();

            }
            var horario = await _context.Horario
                .FirstOrDefaultAsync(m => m.IdHorario == id);
            if (horario == null)
            {
                return NotFound();
            }
            return View(horario);
        }
        //POST: Horario/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horario = await _context.Horario.FindAsync(id);
            _context.Horario.Remove(horario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool HorarioExists(int id)
        {
            return _context.Horario.Any(e => e.IdHorario == id);
        }
    }
}
