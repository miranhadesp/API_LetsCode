using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_Passagem.Models;
using Hotel_Passagem.Services;

namespace Hotel_Passagem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly HotelService service;

        public HotelController(AppDbContext context, HotelService services)
        {
            _context = context;
            service = services;
        }

        // GET: api/Hotel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHoteis()
        {
            return await service.GetHoteis();
        }

        // GET: api/Hotel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await ValidarId(id);

            return hotel.Value == null ? hotel.Result : Ok(hotel.Value);
        }

        // PUT: api/Hotel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Hotel>> PutHotel(int id, Hotel hotel) 
        {
            var verify = await ValidarId(id);

            return verify.Value == null ? verify.Result : Ok(await service.PutHotel(id, hotel));
        }

        // POST: api/Hotel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            if(hotel.Nome == null)
            {
                return BadRequest("Nome nulo");
            }

            return await service.PostHotel(hotel);
        }

        // DELETE: api/Hotel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteHotel(int id)
        {
            var verify = await ValidarId(id);

            return verify.Value == null ? verify.Result : Ok(await service.DeleteHotel(id));
        }

        private async Task<ActionResult<Hotel>> ValidarId(int id)
        {
            try
            {
                var verify = await service.GetHotel(id);

                if (verify == null)
                {
                    return BadRequest("id não encontrado");
                }

                return verify;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
