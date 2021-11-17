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
    public class QuartosController : ControllerBase
    {
        private readonly QuartoService quartoService; 

        public QuartosController(QuartoService quartoService)
        {
            this.quartoService = quartoService;
        }

        // GET: api/Quartos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quarto>>> GetQuartos()
        {
            return await quartoService.GetQuartos();
        }

        // GET: api/Quartos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quarto>> GetQuarto(int id)
        {
            return await quartoService.GetQuarto(id);
        }

        // PUT: api/Quartos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Quarto>> PutQuarto(int id, Quarto quarto)
        {
            var validado = new QuartoValidations().Validate(quarto);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await quartoService.PutQuarto(id, quarto);
        }

        // POST: api/Quartos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quarto>> PostQuarto(Quarto quarto)
        {
            var validado = new QuartoValidations().Validate(quarto);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await quartoService.PostQuarto(quarto);
        }

        // DELETE: api/Quartos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteQuarto(int id)
        {
            return await quartoService.DeleteQuarto(id);
        }
    }
}
