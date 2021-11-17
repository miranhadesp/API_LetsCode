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
    public class ReservaQuartosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservaQuartosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ReservaQuartos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaQuarto>>> GetReservaQuartos()
        {
            return await _context.ReservaQuartos.ToListAsync();
        }

        // GET: api/ReservaQuartos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaQuarto>> GetReservaQuarto(int id)
        {
            var reservaQuarto = await _context.ReservaQuartos.FindAsync(id);

            if (reservaQuarto == null)
            {
                return NotFound();
            }

            return reservaQuarto;
        }

        // PUT: api/ReservaQuartos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservaQuarto(int id, ReservaQuarto reservaQuarto)
        {
            if (id != reservaQuarto.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservaQuarto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaQuartoExists(id))
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

        // POST: api/ReservaQuartos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservaQuarto>> PostReservaQuarto(ReservaQuarto reservaQuarto)
        {
            _context.ReservaQuartos.Add(reservaQuarto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservaQuarto", new { id = reservaQuarto.Id }, reservaQuarto);
        }

        // DELETE: api/ReservaQuartos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservaQuarto(int id)
        {
            var reservaQuarto = await _context.ReservaQuartos.FindAsync(id);
            if (reservaQuarto == null)
            {
                return NotFound();
            }

            _context.ReservaQuartos.Remove(reservaQuarto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaQuartoExists(int id)
        {
            return _context.ReservaQuartos.Any(e => e.Id == id);
        }
    }
}
