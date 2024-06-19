using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicaAPI.Extensions;
using MusicaAPI.Interfaces;
using MusicaAPI.Models;
using MusicaAPI.Dtos.Agenda;
using System.Linq;
using MusicaAPI.Mappers;

namespace MusicaAPI.Controllers
{

    [Route("MusicaAPI/Agenda")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAgendaRepository _agendaRepo;
        private readonly ISalaRepository _salaRepo;
        public AgendaController(UserManager<AppUser> userManager, IAgendaRepository agendaRepo, ISalaRepository salaRepo)
        {
            _userManager = userManager;
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
    }
}
