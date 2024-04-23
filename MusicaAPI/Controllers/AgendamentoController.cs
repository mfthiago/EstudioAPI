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

        public AgendamentoController(IAgendamentoRepository agendamentoRepo)
        {
            _agendamentoRepo = agendamentoRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var agendamentos = await _agendamentoRepo.GetAllAsync();
            var agendamentoDto = agendamentos.Select(s => s.ToAgendamentoDto());

            return Ok(agendamentoDto);

        }

    }
}
