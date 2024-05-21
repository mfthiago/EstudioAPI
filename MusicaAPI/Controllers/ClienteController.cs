using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Data;
using MusicaAPI.Mappers;
using MusicaAPI.Dtos;
using MusicaAPI.Dtos.Cliente;
using Microsoft.EntityFrameworkCore;
using MusicaAPI.Interfaces;
using MusicaAPI.Helpers;

namespace MusicaAPI.Controllers
{
    [Route("MusicaAPI/Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IClienteRepository _clienteRepo;
        public ClienteController(ApplicationDbContext context, IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clientes = await _clienteRepo.GetAllAsync(query);
            var clienteDto = clientes.Select(s => s.ToClienteDto());

            return Ok(clienteDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cliente = await _clienteRepo.GetByIdAsync(id);

            if(cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente.ToClienteDto());
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateClienteRequestDto clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clienteModel = clienteDto.ToClienteFromCreateDTO();
            await _clienteRepo.CreateAsync(clienteModel);
            return CreatedAtAction(nameof(GetById), new { id = clienteModel.Id }, clienteModel.ToClienteDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateClienteRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clienteModel = await _clienteRepo.UpdateAsync(id, updateDto);

            if(clienteModel == null)
            {
                return NotFound();
            }


            return Ok(clienteModel.ToClienteDto());

        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var clienteModel = await _clienteRepo.DeleteAsync(id);
            if(clienteModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
