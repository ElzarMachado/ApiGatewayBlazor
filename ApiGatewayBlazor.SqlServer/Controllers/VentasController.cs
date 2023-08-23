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
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> Index()
        {
            var ventas = await _context.Venta.ToListAsync();
            return Ok(ventas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var ventas = await _context.Venta.FindAsync(id);

            if (ventas == null)
            {
                return NotFound();
            }

            return Ok(ventas);
        }

        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta([FromBody] Venta ventas)
        {
            _context.Venta.Add(ventas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentas", new { Id = ventas.IdVenta }, ventas);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, Venta ventas)
        {
            if (id != ventas.IdVenta)
            {
                return BadRequest();
            }

            _context.Entry(ventas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var ventas = await _context.Venta.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }

            _context.Venta.Remove(ventas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaExists(int id)
        {
            return _context.Venta.Any(e => e.IdVenta == id);
        }
    }
}

//        // GET: Ventas
//        public async Task<IActionResult> Index()
//        {
//              return _context.Venta != null ? 
//                          View(await _context.Venta.ToListAsync()) :
//                          Problem("Entity set 'ApplicationDbContext.Venta'  is null.");
//        }

//        // GET: Ventas/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Venta == null)
//            {
//                return NotFound();
//            }

//            var venta = await _context.Venta
//                .FirstOrDefaultAsync(m => m.IdVenta == id);
//            if (venta == null)
//            {
//                return NotFound();
//            }

//            return View(venta);
//        }

//        // GET: Ventas/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Ventas/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("IdVenta,IdProducto,IdCliente,Cantidad")] Venta venta)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(venta);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(venta);
//        }

//        // GET: Ventas/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Venta == null)
//            {
//                return NotFound();
//            }

//            var venta = await _context.Venta.FindAsync(id);
//            if (venta == null)
//            {
//                return NotFound();
//            }
//            return View(venta);
//        }

//        // POST: Ventas/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("IdVenta,IdProducto,IdCliente,Cantidad")] Venta venta)
//        {
//            if (id != venta.IdVenta)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(venta);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!VentaExists(venta.IdVenta))
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
//            return View(venta);
//        }

//        // GET: Ventas/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Venta == null)
//            {
//                return NotFound();
//            }

//            var venta = await _context.Venta
//                .FirstOrDefaultAsync(m => m.IdVenta == id);
//            if (venta == null)
//            {
//                return NotFound();
//            }

//            return View(venta);
//        }

//        // POST: Ventas/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Venta == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.Venta'  is null.");
//            }
//            var venta = await _context.Venta.FindAsync(id);
//            if (venta != null)
//            {
//                _context.Venta.Remove(venta);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool VentaExists(int id)
//        {
//          return (_context.Venta?.Any(e => e.IdVenta == id)).GetValueOrDefault();
//        }
//    }
//}
