using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICliente.Data;
using APICliente.Models;

namespace APICliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // Opción creada
        [HttpGet("{cedula}/clientebycedula")]
        public async Task<IEnumerable<Cliente>> Search(string cedula) {
            //var result = _context.Cliente.AsQueryable(); --> Otra forma en la que puede servir
            IQueryable<Cliente> query = _context.Cliente;
            //query = query.Where(e => e.Cedula.Contains(cedula)); --> Verifica si el texto contiene lo enviado como parametro
            //query = query.Where(e => e.Cedula.StartsWith(cedula)) --> Verifica si el texto empieza con lo enviado como parametro

            query = query.Where(e => e.Cedula == cedula);
            if (query == null)
            {
                return null;

            }
            return await query.ToListAsync();
        }

        [HttpGet("{apellido}/EmpiezaApellidoCon")]
        public async Task<IEnumerable<Cliente>> BuscaApellido(string apellido)
        {
            IQueryable<Cliente> query = _context.Cliente;
            query = query.Where(e => e.Apellido.StartsWith(apellido)); // --> Verifica si el texto empieza con lo enviado como parametro
            if (query == null)
            {
                return null;

            }
            return await query.ToListAsync();
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCliente()
        {
          if (_context.Cliente == null)
          {
              return NotFound();
          }
            return await _context.Cliente.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int? id)
        {
          if (_context.Cliente == null)
          {
              return NotFound();
          }
            var cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int? id, Cliente cliente)
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
          if (_context.Cliente == null)
          {
              return Problem("Entity set 'AppDbContext.Cliente'  is null.");
          }
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int? id)
        {
            if (_context.Cliente == null)
            {
                return NotFound();
            }
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int? id)
        {
            return (_context.Cliente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
