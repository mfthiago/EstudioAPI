using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Data;
using MusicaAPI.Mappers;
using MusicaAPI.Dtos;
using MusicaAPI.Dtos.Cliente;

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
        public IActionResult GetAll()
        {
            var clientes = _context.Clientes.ToList()
                .Select(s => s.ToClienteDto());

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var cliente = _context.Clientes.Find(id);

            if(cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente.ToClienteDto());
        }

        [HttpPost]

        public IActionResult Create([FromBody] CreateClienteRequestDto clienteDto)
        {
            var clienteModel = clienteDto.ToClienteFromCreateDTO();
            _context.Clientes.Add(clienteModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = clienteModel.Id }, clienteModel.ToClienteDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateClienteRequestDto updateDto)
        {
            var clienteModel = _context.Clientes.FirstOrDefault(x => x.Id == id);

            if(clienteModel == null)
            {
                return NotFound();
            }

            clienteModel.Nome = updateDto.Nome;
            clienteModel.Email = updateDto.Email;
            clienteModel.Telefone = updateDto.Telefone;

            _context.SaveChanges();

            return Ok(clienteModel.ToClienteDto());

        }

    }
}
