using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Data;
using MusicaAPI.Mappers;
using MusicaAPI.Dtos;
using MusicaAPI.Dtos.Cliente;
using Microsoft.EntityFrameworkCore;

namespace MusicaAPI.Controllers
{
    [Route("MusicaAPI/Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _context.Clientes.ToListAsync();
            var clienteDto = clientes.Select(s => s.ToClienteDto());

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if(cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente.ToClienteDto());
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateClienteRequestDto clienteDto)
        {
            var clienteModel = clienteDto.ToClienteFromCreateDTO();
            await _context.Clientes.AddAsync(clienteModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = clienteModel.Id }, clienteModel.ToClienteDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClienteRequestDto updateDto)
        {
            var clienteModel = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if(clienteModel == null)
            {
                return NotFound();
            }

            clienteModel.Nome = updateDto.Nome;
            clienteModel.Email = updateDto.Email;
            clienteModel.Telefone = updateDto.Telefone;

            await _context.SaveChangesAsync();

            return Ok(clienteModel.ToClienteDto());

        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var clienteModel = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if(clienteModel == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(clienteModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
