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
    public class CompanhiasController : ControllerBase
    {
        private readonly CompanhiaService _context;

        public CompanhiasController(CompanhiaService context)
        {
            _context = context;
        }

        // GET: api/Companhias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Companhia>>> GetCompanhias()
        {
            return await _context.GetCompanhias();
        }

        // GET: api/Companhias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Companhia>> GetCompanhia(int id)
        {
            return await _context.GetCompanhia(id);
        }

        // PUT: api/Companhias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Companhia>> PutCompanhia(int id, Companhia companhia)
        {
            var validado = new CompanhiaValidations().Validate(companhia);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await _context.PutCompanhia(id, companhia);
        }

        // POST: api/Companhias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Companhia>> PostCompanhia(Companhia companhia)
        {
            var validado = new CompanhiaValidations().Validate(companhia);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await _context.PostCompanhia(companhia);
        }

        // DELETE: api/Companhias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteCompanhia(int id)
        {
            return await _context.DeleteCompanhia(id);
        }
    }
}
