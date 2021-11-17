using Hotel_Passagem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel_Passagem.Services
{
    public class HotelService
    {
        private readonly AppDbContext _context;

        public HotelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Hotel>>> GetAllHoteis()
        {
            return await _context.Hotels.ToListAsync();
        }

       
        public async Task<ActionResult<Hotel>> GetOneHotel(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            return hotel;
        }
       
        public async Task<ActionResult<Hotel>> PutHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            var aux = await _context.Hotels.FirstOrDefaultAsync(i => i.Id == id);

            return aux;
        }
   
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();

            return hotel;
        }
      
        public async Task<ActionResult<string>> DeleteHotel(int id)
        {
            var hotel = await _context.Hotels.FirstOrDefaultAsync(i => i.Id == id);           

            if (hotel != null)
            _context.Hotels.Remove(hotel);

            await _context.SaveChangesAsync();

            return "OK";
        }
    }
}
