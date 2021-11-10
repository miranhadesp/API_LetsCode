using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_Passagem.Models;

namespace Hotel_Passagem.Services
{
    public class HotelService
    {
        private readonly AppDbContext dbContext;

        public HotelService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Get all pizzas
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHoteis()
        {
            return await dbContext.Hoteis.Include(p => p.Quartos).ToListAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            var hotel = await dbContext.Hoteis.Include(p => p.Quartos).Where(j => j.Id == id).FirstOrDefaultAsync();

            return hotel;
        }

        public async Task<Hotel> PutHotel(int id, Hotel hotel)
        {
            dbContext.Entry(hotel).State = EntityState.Modified;

            await dbContext.SaveChangesAsync();

            var p = await GetHotel(id);

            return p;
        }

        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            dbContext.Hoteis.Add(hotel);

            await dbContext.SaveChangesAsync();

            var p = await GetHotel(hotel.Id);

            return p;
        }

        public async Task<ActionResult<string>> DeleteHotel(int id)
        {
            var hotel = await dbContext.Hoteis.Include(p => p.Quartos).Where(j => j.Id == id).FirstOrDefaultAsync();

            if (hotel != null)
            {
                dbContext.Hoteis.Remove(hotel);

                await dbContext.SaveChangesAsync();

                return "Removido com sucesso!";
            }
            return "Falha ao remover";
        }


    }
}

