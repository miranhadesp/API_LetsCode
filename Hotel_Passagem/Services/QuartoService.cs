using Hotel_Passagem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_Passagem.Services
{
    public class QuartoService
    {
        private readonly AppDbContext _context;

        public QuartoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Quarto>>> GetQuartos()
        {
            return await _context.Quartos.ToListAsync();
        }

        public async Task<ActionResult<Quarto>> GetQuarto(int id)
        {
            var quarto = await _context.Quartos.FindAsync(id);
            return quarto;
        }

        public async Task<ActionResult<Quarto>> PutQuarto(int id, Quarto quarto)
        {
            _context.Entry(quarto).State = EntityState.Modified;         
            await _context.SaveChangesAsync();
            var aux = await _context.Quartos.FirstOrDefaultAsync(i => i.Id == id);
            return aux;
        }

        public async Task<ActionResult<Quarto>> PostQuarto(Quarto quarto)
        {
            _context.Quartos.Add(quarto);
            await _context.SaveChangesAsync();

            return quarto;
        }

        public async Task<ActionResult<string>> DeleteQuarto(int id)
        {
            var quarto = await _context.Quartos.FindAsync(id);
            _context.Quartos.Remove(quarto);
            await _context.SaveChangesAsync();

            return "Ok";
        }
    }
}
