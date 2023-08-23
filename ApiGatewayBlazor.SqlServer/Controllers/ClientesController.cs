using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiGatewayBlazor.SqlServer.Datos;
using ApiGatewayBlazor.SqlServer.Models;
using System.Diagnostics;

namespace ApiGatewayBlazor.SqlServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Index()
        {
            var cliente = await _context.Cliente.ToListAsync();
            return Ok(cliente);
        }


        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> ObtenerCliente()
        {
            return await _context.Cliente.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente([FromBody] Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientes", new { cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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
        public async Task<IActionResult> BorrarCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Id == id);
        }
    }
}

//            return View(cliente);
//        }

//        // GET: Clientes/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Clientes/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Nombre")] Cliente cliente)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(cliente);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(cliente);
//        }

//        // GET: Clientes/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Cliente == null)
//            {
//                return NotFound();
//            }

//            var cliente = await _context.Cliente.FindAsync(id);
//            if (cliente == null)
//            {
//                return NotFound();
//            }
//            return View(cliente);
//        }

//        // POST: Clientes/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Cliente cliente)
//        {
//            if (id != cliente.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(cliente);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ClienteExists(cliente.Id))
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
//            return View(cliente);
//        }

//        // GET: Clientes/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Cliente == null)
//            {
//                return NotFound();
//            }

//            var cliente = await _context.Cliente
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (cliente == null)
//            {
//                return NotFound();
//            }

//            return View(cliente);
//        }

//        // POST: Clientes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Cliente == null)
//            {
//                return Problem("Entity set 'ApplicationDbContext.Cliente'  is null.");
//            }
//            var cliente = await _context.Cliente.FindAsync(id);
//            if (cliente != null)
//            {
//                _context.Cliente.Remove(cliente);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ClienteExists(int id)
//        {
//          return (_context.Cliente?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
