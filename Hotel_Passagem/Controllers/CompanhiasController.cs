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
    public class CompanhiasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompanhiasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Companhias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Companhia>>> GetCompanhia()
        {
            return await _context.Companhia.ToListAsync();
        }

        // GET: api/Companhias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Companhia>> GetCompanhia(int id)
        {
            var companhia = await _context.Companhia.FindAsync(id);

            if (companhia == null)
            {
                return NotFound();
            }

            return companhia;
        }

        // PUT: api/Companhias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanhia(int id, Companhia companhia)
        {
            if (id != companhia.Id)
            {
                return BadRequest();
            }

            _context.Entry(companhia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanhiaExists(id))
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

        // POST: api/Companhias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Companhia>> PostCompanhia(Companhia companhia)
        {
            _context.Companhia.Add(companhia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanhia", new { id = companhia.Id }, companhia);
        }

        // DELETE: api/Companhias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanhia(int id)
        {
            var companhia = await _context.Companhia.FindAsync(id);
            if (companhia == null)
            {
                return NotFound();
            }

            _context.Companhia.Remove(companhia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanhiaExists(int id)
        {
            return _context.Companhia.Any(e => e.Id == id);
        }
    }
}
