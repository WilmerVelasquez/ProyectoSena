using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoSena.Core;
using ProyectoSena.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSena.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProyectoSenaDbContext _context;

        public ProductoController(ProyectoSenaDbContext context)
        {
            _context = context;
        }
        //GET: Producto
        public async Task<IActionResult> Index()
        {
            var ProyectoSenaDbContext = _context.Producto.Include(p => p.IdSuministroNavigation);
            return View(await ProyectoSenaDbContext.ToListAsync());
        }
        //GET:Producto/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.IdSuministroNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if(producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }
        //GET : Producto/Create
        public IActionResult Create()
        {
            ViewData["IdSuministro"] = new SelectList(_context.Suministro, "IdSuministro", "IdSuministro");
            return View();
                       
            
        }
        //POST:Producto/CReate
        public async Task<IActionResult> Create([Bind("IdProducto,NombreProducto,CantidadDisponible,Medidas,IdSuministro")] Producto producto)
        {
            if(ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSuministro"] = new SelectList(_context.Suministro, "IdSuministro", "IdSuministro", producto.IdSuministro);
            return View(producto);
        }
            //GET:Producto/Edit
            public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producto = await _context.Producto.FindAsync(id);
            if(producto == null)
            {
                return NotFound();
            }
            ViewData["IdSuministro"] = new SelectList(_context.Suministro, "IdSuministro", "IdSuministro", producto.IdSuministro);
            return View(producto);
        }
        // POST: Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,NombreProducto,CantidadDisponible,Medidas,IdSuministro")] Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.IdProducto))
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
            ViewData["IdSuministro"] = new SelectList(_context.Suministro, "IdSuministro", "IdSuministro", producto.IdSuministro);
            return View(producto);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.IdSuministroNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.IdProducto == id);
        }
    }
}
