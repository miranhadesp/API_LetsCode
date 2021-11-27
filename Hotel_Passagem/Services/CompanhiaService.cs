using Hotel_Passagem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_Passagem.Services
{
    public class CompanhiaService
    {
        private readonly AppDbContext _context;

        public CompanhiaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Companhia>>> GetCompanhias()
        {
            return await _context.Companhia.ToListAsync();
        }

        public async Task<ActionResult<Companhia>> GetCompanhia(int id)
        {
            var companhia = await _context.Companhia.FindAsync(id);

            return companhia;
        }

        public async Task<ActionResult<Companhia>> PutCompanhia(int id, Companhia companhia)
        {
            _context.Entry(companhia).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return companhia;
        }

        public async Task<ActionResult<Companhia>> PostCompanhia(Companhia companhia)
        {
            _context.Companhia.Add(companhia);
            await _context.SaveChangesAsync();

            return companhia;
        }

        public async Task<ActionResult<string>> DeleteCompanhia(int id)
        {
            var companhia = await _context.Companhia.FindAsync(id);

            _context.Companhia.Remove(companhia);
            await _context.SaveChangesAsync();

            return "OK";
        }

    }
}
