using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_Passagem.Models;
using Hotel_Passagem.Services;
using Hotel_Passagem.Validations;

namespace Hotel_Passagem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoteisController : ControllerBase
    {
        private readonly HotelService hotelService;

        public HoteisController(HotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        // GET: api/Hoteis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHoteis()
        {
            return await hotelService.GetAllHoteis();
        }

        // GET: api/Hoteis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            return await hotelService.GetOneHotel(id);
        }
        
        // PUT: api/Hoteis/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Hotel>> PutHotel(int id, Hotel hotel)
        {
            var validado = new HotelValidations().Validate(hotel);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await hotelService.PutHotel(id, hotel);
        }

        // POST: api/Hoteis
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            var validado = new HotelValidations().Validate(hotel);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await hotelService.PostHotel(hotel);
        }

        // DELETE: api/Hoteis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<String>> DeleteHotel(int id)
        {
            return await hotelService.DeleteHotel(id);
        } 
    }
}
