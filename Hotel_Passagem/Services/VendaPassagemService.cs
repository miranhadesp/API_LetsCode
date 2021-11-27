using Hotel_Passagem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_Passagem.Services
{
    public class VendaPassagemService
    {
        private readonly AppDbContext _context;

        public VendaPassagemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<VendaPassagem>>> GetVendaPassagems()
        {
            return await _context.VendaPassagems.ToListAsync();
        }

        public async Task<ActionResult<VendaPassagem>> GetVendaPassagem(int id)
        {
            var vendaPassagem = await _context.VendaPassagems.FindAsync(id);       

            return vendaPassagem;
        }

        public async Task<ActionResult<VendaPassagem>> PutVendaPassagem(int id, VendaPassagem vendaPassagem)
        {

            _context.Entry(vendaPassagem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return vendaPassagem;
        }

        public async Task<ActionResult<VendaPassagem>> PostVendaPassagem(VendaPassagem vendaPassagem)
        {
            _context.VendaPassagems.Add(vendaPassagem);
            await _context.SaveChangesAsync();

            return vendaPassagem;
        }

        public async Task<ActionResult<string>> DeleteVendaPassagem(int id)
        {
            var vendaPassagem = await _context.VendaPassagems.FindAsync(id);
            _context.VendaPassagems.Remove(vendaPassagem);
            await _context.SaveChangesAsync();

            return "OK";
        }
    }
}
