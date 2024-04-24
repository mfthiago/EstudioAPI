using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Interfaces;
using MusicaAPI.Dtos.Agendamento;
using MusicaAPI.Mappers;

namespace MusicaAPI.Controllers
{

    [Route("MusicaAPI/Agendamento")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoRepository _agendamentoRepo;
        private readonly IClienteRepository _clienteRepo;
        private readonly IEstudioRepository _estudioRepo;
        private readonly ISalaRepository _salaRepo;
        public AgendamentoController(IAgendamentoRepository agendamentoRepo, IClienteRepository clienteRepo, IEstudioRepository estudioRepo, ISalaRepository salaRepo)
        {
            _agendamentoRepo = agendamentoRepo;
            _clienteRepo = clienteRepo;
            _estudioRepo = estudioRepo;
            _salaRepo = salaRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var agendamentos = await _agendamentoRepo.GetAllAsync();
            var agendamentoDto = agendamentos.Select(s => s.ToAgendamentoDto());

            return Ok(agendamentoDto);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var agendamento = await _agendamentoRepo.GetByIdAsync(id);

            if(agendamento == null)
            {
                return NotFound();
            }
            return Ok(agendamento.ToAgendamentoDto());
        }

        [HttpPost("{clienteId},{estudioId},{salaId}")]
        public async Task<IActionResult> Create([FromRoute] int clienteId,int estudioId,int salaId, CreateAgendamentoDto agendamentoDto )
        {
            if(!await _clienteRepo.ClienteExists(clienteId)||
                !await _estudioRepo.EstudioExists(estudioId)||
                !await _salaRepo.SalaExists(salaId))
            {
                return BadRequest("Informações inválidas");
            }
            var agendamentoModel = agendamentoDto.ToAgendamentoFromCreate(clienteId, estudioId, salaId);
            await _agendamentoRepo.CreateAsync(agendamentoModel);
            return CreatedAtAction(nameof(GetById), new { id = agendamentoModel }, agendamentoModel.ToAgendamentoDto());
        }

    }
}
