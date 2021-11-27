using Hotel_Passagem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_Passagem.Services
{
    public class ClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            
            return cliente;
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> PutCliente(int id, Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return cliente;
        }

        // POST: api/Clientes       
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(i => i.Id == id);

            if(cliente != null)
                _context.Clientes.Remove(cliente);

            await _context.SaveChangesAsync();

            return "OK";
        }
    }
}
