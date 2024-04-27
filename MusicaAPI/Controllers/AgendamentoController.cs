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
        private readonly ISalaRepository _salaRepo;
        public AgendamentoController(IAgendamentoRepository agendamentoRepo, IClienteRepository clienteRepo, ISalaRepository salaRepo)
        {
            _agendamentoRepo = agendamentoRepo;
            _clienteRepo = clienteRepo;
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

        [HttpPost("{clienteId:int},{salaId:int}")]
        public async Task<IActionResult> Create([FromRoute] int clienteId,int salaId, CreateAgendamentoDto agendamentoDto )
        {
            if(!await _clienteRepo.ClienteExists(clienteId)||
                !await _salaRepo.SalaExists(salaId))
            {
                return BadRequest("Informações inválidas");
            }
            var agendamentoModel = agendamentoDto.ToAgendamentoFromCreate(clienteId,salaId);
            await _agendamentoRepo.CreateAsync(agendamentoModel);
            return CreatedAtAction(nameof(GetById), new { id = agendamentoModel.Id }, agendamentoModel.ToAgendamentoDto());
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAgendamentoRequestDto updateDto)
        {
            var agendamento = await _agendamentoRepo.UpdateAsync(id, updateDto.ToAgendamentoFromUpdate());
            if(agendamento == null)
            {
                return NotFound("Agendamento não encontrado.");
            }
            return Ok(agendamento.ToAgendamentoDto());

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var agendamentoModel = await _agendamentoRepo.DeleteAsync(id);
            if(agendamentoModel == null)
            {
                return NotFound("Agendamento não existe.");
            }
            return Ok(agendamentoModel);

        }

    }
}
