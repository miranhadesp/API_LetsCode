using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaPassagensController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VendaPassagensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/VendaPassagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaPassagem>>> GetVendaPassagems()
        {
            return await _context.VendaPassagems.ToListAsync();
        }

        // GET: api/VendaPassagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendaPassagem>> GetVendaPassagem(int id)
        {
            var vendaPassagem = await _context.VendaPassagems.FindAsync(id);

            if (vendaPassagem == null)
            {
                return NotFound();
            }

            return vendaPassagem;
        }

        // PUT: api/VendaPassagens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendaPassagem(int id, VendaPassagem vendaPassagem)
        {
            if (id != vendaPassagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(vendaPassagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaPassagemExists(id))
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

        // POST: api/VendaPassagens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VendaPassagem>> PostVendaPassagem(VendaPassagem vendaPassagem)
        {
            _context.VendaPassagems.Add(vendaPassagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendaPassagem", new { id = vendaPassagem.Id }, vendaPassagem);
        }

        // DELETE: api/VendaPassagens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendaPassagem(int id)
        {
            var vendaPassagem = await _context.VendaPassagems.FindAsync(id);
            if (vendaPassagem == null)
            {
                return NotFound();
            }

            _context.VendaPassagems.Remove(vendaPassagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendaPassagemExists(int id)
        {
            return _context.VendaPassagems.Any(e => e.Id == id);
        }
    }
}
