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
    public class ReservaQuartosController : ControllerBase
    {
        private readonly ReservaQuartoService _context;

        public ReservaQuartosController(ReservaQuartoService context)
        {
            _context = context;
        }

        // GET: api/ReservaQuartos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaQuarto>>> GetReservaQuartos()
        {
            return await _context.GetReservaQuartos();
        }

        // GET: api/ReservaQuartos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaQuarto>> GetReservaQuarto(int id)
        {
            return await _context.GetReservaQuarto(id);
        }

        // PUT: api/ReservaQuartos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ReservaQuarto>> PutReservaQuarto(int id, ReservaQuarto reservaQuarto)
        {
            var validado = new ReservaQuartoValidations().Validate(reservaQuarto);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await _context.PutReservaQuarto(id, reservaQuarto);
        }

        // POST: api/ReservaQuartos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservaQuarto>> PostReservaQuarto(ReservaQuarto reservaQuarto)
        {
            var validado = new ReservaQuartoValidations().Validate(reservaQuarto);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await _context.PostReservaQuarto(reservaQuarto);
        }

        // DELETE: api/ReservaQuartos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteReservaQuarto(int id)
        {
            return await _context.DeleteReservaQuarto(id);
        }
    }
}
