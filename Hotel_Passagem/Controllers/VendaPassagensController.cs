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
    public class VendaPassagensController : ControllerBase
    {
        private readonly VendaPassagemService _context;

        public VendaPassagensController(VendaPassagemService context)
        {
            _context = context;
        }

        // GET: api/VendaPassagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendaPassagem>>> GetVendaPassagems()
        {
            return await _context.GetVendaPassagems();
        }

        // GET: api/VendaPassagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendaPassagem>> GetVendaPassagem(int id)
        {
            return await _context.GetVendaPassagem(id);
        }

        // PUT: api/VendaPassagens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<VendaPassagem>> PutVendaPassagem(int id, VendaPassagem vendaPassagem)
        {
            var validado = new VendaPassagemValidations().Validate(vendaPassagem);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await _context.PutVendaPassagem(id, vendaPassagem);
        }

        // POST: api/VendaPassagens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VendaPassagem>> PostVendaPassagem(VendaPassagem vendaPassagem)
        {
            var validado = new VendaPassagemValidations().Validate(vendaPassagem);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await _context.PostVendaPassagem(vendaPassagem);
        }

        // DELETE: api/VendaPassagens/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteVendaPassagem(int id)
        {
            return await _context.DeleteVendaPassagem(id);
        }
    }
    
}
