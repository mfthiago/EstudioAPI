using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Data;

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
            var clientes = _context.Clientes.ToList();

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
            return Ok(cliente);
        }

    }
}
