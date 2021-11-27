using Hotel_Passagem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_Passagem.Services
{
    public class ReservaQuartoService
    {
        private readonly AppDbContext _context;

        public ReservaQuartoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<ReservaQuarto>>> GetReservaQuartos()
        {
            return await _context.ReservaQuartos.ToListAsync();
        }

        public async Task<ActionResult<ReservaQuarto>> GetReservaQuarto(int id)
        {
            var reservaQuarto = await _context.ReservaQuartos.FindAsync(id);

            return reservaQuarto;
        }

        public async Task<ActionResult<ReservaQuarto>> PutReservaQuarto(int id, ReservaQuarto reservaQuarto)
        {
            _context.Entry(reservaQuarto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return reservaQuarto;
        }

        public async Task<ActionResult<ReservaQuarto>> PostReservaQuarto(ReservaQuarto reservaQuarto)
        {
            _context.ReservaQuartos.Add(reservaQuarto);
            await _context.SaveChangesAsync();

            return reservaQuarto;
        }

        public async Task<ActionResult<string>> DeleteReservaQuarto(int id)
        {
            var reservaQuarto = await _context.ReservaQuartos.FindAsync(id);           
            _context.ReservaQuartos.Remove(reservaQuarto);
            await _context.SaveChangesAsync();

            return "OK";
        }
    }
}
