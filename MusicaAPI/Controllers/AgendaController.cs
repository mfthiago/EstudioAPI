using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Extensions;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;

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
        public AgendaController(UserManager<AppUser> userManager,IAgendaRepository agendaRepo, IClienteRepository clienteRepo,IAgendamentoRepository agendamentoRepo)
        {
            _userManager = userManager;
            _agendamentoRepo = agendamentoRepo;
            _clienteRepo = clienteRepo;
            _agendaRepo = agendaRepo;
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

    }
}
