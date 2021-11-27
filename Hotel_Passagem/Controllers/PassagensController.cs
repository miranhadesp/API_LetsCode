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
    public class PassagensController : ControllerBase
    {
        private readonly PassagemService _context;

        public PassagensController(PassagemService context)
        {
            _context = context;
        }

        // GET: api/Passagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passagem>>> GetPassagems()
        {
            return await _context.GetPassagems();
        }

        // GET: api/Passagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passagem>> GetPassagem(int id)
        {
            return await _context.GetPassagem(id);
        }

        // PUT: api/Passagens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Passagem>> PutPassagem(int id, Passagem passagem)
        {
            var validado = new PassagemValidations().Validate(passagem);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await _context.PutPassagem(id, passagem);
        }

        // POST: api/Passagens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passagem>> PostPassagem(Passagem passagem)
        {
            var validado = new PassagemValidations().Validate(passagem);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await _context.PostPassagem(passagem);
        }

        // DELETE: api/Passagens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeletePassagem(int id)
        {
            return await _context.DeletePassagem(id);
        }
    }
}
