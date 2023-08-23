using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiGatewayBlazor.SqlServer.Datos;
using ApiGatewayBlazor.SqlServer.Models;

namespace ApiGatewayBlazor.SqlServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            var productos = await _context.Producto.ToListAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Producto.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Producto producto)
        {
            var productoAdd = new Producto();
            productoAdd.NombreProducto = producto.NombreProducto;
            productoAdd.Precio = producto.Precio;


            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

//        // GET: Productoes
//        public async Task<IActionResult> Index()
//        {
//              return _context.Producto != null ? 
//                          View(await _context.Producto.ToListAsync()) :
//                          Problem("Entity set 'ApplicationDbContext.Producto'  is null.");
//        }

//        // GET: Productoes/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Producto == null)
//            {
//                return NotFound();
//            }

//            var producto = await _context.Producto
//                .FirstOrDefaultAsync(m => m.IdProducto == id);
//            if (producto == null)
//            {
//                return NotFound();
//            }

//            return View(producto);
//        }

//        // GET: Productoes/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Productoes/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("IdProducto,NombreProducto,Precio")] Producto producto)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(producto);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(producto);
//        }

//        // GET: Productoes/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Producto == null)
//            {
//                return NotFound();
//            }

//            var producto = await _context.Producto.FindAsync(id);
//            if (producto == null)
//            {
//                return NotFound();
//            }
//            return View(producto);
//        }

//        // POST: Productoes/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,NombreProducto,Precio")] Producto producto)
//        {
//            if (id != producto.IdProducto)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(producto);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ProductoExists(producto.IdProducto))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(producto);
//        }

//        // GET: Productoes/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Producto == null)
//            {
//                return NotFound();
//            }

//            var producto = await _context.Producto
//                .FirstOrDefaultAsync(m => m.IdProducto == id);
//            if (producto == null)
//            {
//                return NotFound();
//            }

//            return View(producto);
//        }

//        // POST: Productoes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Producto == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.Producto'  is null.");
//            }
//            var producto = await _context.Producto.FindAsync(id);
//            if (producto != null)
//            {
//                _context.Producto.Remove(producto);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ProductoExists(int id)
//        {
//          return (_context.Producto?.Any(e => e.IdProducto == id)).GetValueOrDefault();
//        }
//    }
//}
