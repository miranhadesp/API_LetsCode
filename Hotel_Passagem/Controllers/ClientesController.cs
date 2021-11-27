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
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService clienteService;

        public ClientesController(ClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await clienteService.GetClientes();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            return await clienteService.GetCliente(id);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> PutCliente(int id, Cliente cliente)
        {
            var validado = new ClienteValidations().Validate(cliente);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await clienteService.PutCliente(id, cliente);
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            var validado = new ClienteValidations().Validate(cliente);
            if (!validado.IsValid)
                return BadRequest(validado.Erros);

            return await clienteService.PostCliente(cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteCliente(int id)
        {
            return await clienteService.DeleteCliente(id);
        }
    }
}
