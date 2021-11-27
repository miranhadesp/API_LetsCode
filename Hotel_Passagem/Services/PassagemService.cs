using Hotel_Passagem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_Passagem.Services
{
    public class PassagemService
    {
        private readonly AppDbContext _context;

        public PassagemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Passagem>>> GetPassagems()
        {
            return await _context.Passagems.ToListAsync();
        }

        public async Task<ActionResult<Passagem>> GetPassagem(int id)
        {
            var passagem = await _context.Passagems.FindAsync(id);
            return passagem;
        }

        public async Task<ActionResult<Passagem>> PutPassagem(int id, Passagem passagem)
        {
            _context.Entry(passagem).State = EntityState.Modified;
         
            await _context.SaveChangesAsync();
            
            return passagem;
        }
        public async Task<ActionResult<Passagem>> PostPassagem(Passagem passagem)
        {
            _context.Passagems.Add(passagem);
            await _context.SaveChangesAsync();

            return passagem;
        }

        public async Task<ActionResult<string>> DeletePassagem(int id)
        {
            var passagem = await _context.Passagems.FindAsync(id);

            _context.Passagems.Remove(passagem);
            await _context.SaveChangesAsync();

            return "OK";
        }
    }
}
