using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Extensions;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;
using MusicaAPI.Dtos.Agendamento;

namespace MusicaAPI.Controllers
{

    [Route("MusicaAPI/Agenda")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IClienteRepository _clienteRepo;
        private readonly IAgendamentoRepository _agendamentoRepo;
        private readonly IAgendaRepository _agendaRepo;
        private readonly ISalaRepository _salaRepo;
        public AgendaController(UserManager<AppUser> userManager,IAgendaRepository agendaRepo, IClienteRepository clienteRepo,IAgendamentoRepository agendamentoRepo,ISalaRepository salaRepo)
        {
            _userManager = userManager;
            _agendamentoRepo = agendamentoRepo;
            _clienteRepo = clienteRepo;
            _agendaRepo = agendaRepo;
            _salaRepo = salaRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserAgenda()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userAgenda = await _agendaRepo.GetUserAgenda(appUser);
            return Ok(userAgenda);  
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAgenda(string nome,int salaId)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var cliente = await _clienteRepo.GetByNameAsync(nome);
            var sala = await _salaRepo.GetByIdAsync(salaId);
            var agendamento = await _agendamentoRepo.GetAllAsync();

            if(cliente == null) return BadRequest("Cliente não encontrado");
            if (sala == null) return BadRequest("Saça não encontrada");

            var userAgenda = await _agendaRepo.GetUserAgenda(appUser);

            var agendamentoModel = agendamentoDto.ToAgendamentoFromCreate(clienteId, salaId);
            var minDate = DateTime.Now;
            if (agendamentoModel.DataInicial < minDate)
            {
                return BadRequest("Data inválida");
            }
            if (await _agendamentoRepo.AgendamentoExistsData(agendamentoModel, salaId))
            {
                return BadRequest("Já existe um agenndamento nesse horário");
            }

        }

    }
}
